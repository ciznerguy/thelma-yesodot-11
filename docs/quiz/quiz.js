(function(){
  var D = window.QUIZ;
  var HEB = /[֐-׿]/;
  function esc(s){return String(s).replace(/&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;");}
  // עטיפת קטעי קוד לטיניים בתוך טקסט עברית, כדי שלא יתהפכו
  function fmt(s){
    if(!HEB.test(s)){ return "<bdi dir=\"ltr\">"+esc(s)+"</bdi>"; }
    return esc(s).replace(/[A-Za-z_][A-Za-z0-9_.\[\],<>()=!&|+*\/%"';{}:-]*(?: [A-Za-z0-9_.\[\],<>()=!&|+*\/%"';{}:-]+)*/g,function(m){return "<bdi dir=\"ltr\">"+m+"</bdi>";});
  }
  function shuffle(a){for(var i=a.length-1;i>0;i--){var j=Math.floor(Math.random()*(i+1));var t=a[i];a[i]=a[j];a[j]=t;}return a;}
  var qs = D.questions.map(function(q,i){
    var opts = [{t:q.right,ok:true}].concat(q.wrongs.map(function(w){return {t:w,ok:false};}));
    return {i:i,topic:q.topic,text:q.text,code:q.code,why:q.why,opts:shuffle(opts),picked:-1};
  });
  var root=document.getElementById("quiz"), bar=document.getElementById("fill"), cnt=document.getElementById("cnt");
  var locked=false, warned=false;
  function render(){
    var h="";
    qs.forEach(function(q){
      h+="<article class=\"card\" id=\"q"+q.i+"\"><div class=\"qh\"><span class=\"qn\">"+(q.i+1)+"</span><span class=\"chip\">"+esc(D.topics[q.topic])+"</span></div>";
      h+="<div class=\"qt\">"+fmt(q.text)+"</div>";
      if(q.code){h+="<pre>"+esc(q.code)+"</pre>";}
      h+="<div class=\"opts\">";
      q.opts.forEach(function(o,k){
        h+="<label class=\"opt\" id=\"o"+q.i+"_"+k+"\"><input type=\"radio\" name=\"q"+q.i+"\" value=\""+k+"\"><span>"+fmt(o.t)+"</span></label>";
      });
      h+="</div><div class=\"why\" style=\"display:none\"></div></article>";
    });
    root.innerHTML=h;
    root.addEventListener("change",function(e){
      if(locked||e.target.type!=="radio")return;
      var qi=+e.target.name.slice(1), k=+e.target.value;
      qs[qi].picked=k;
      qs[qi].opts.forEach(function(_,j){document.getElementById("o"+qi+"_"+j).classList.toggle("sel",j===k);});
      progress();
    });
  }
  function answered(){return qs.filter(function(q){return q.picked>=0;}).length;}
  function progress(){var a=answered();cnt.textContent=a+" מתוך "+qs.length+" נענו";bar.style.width=(a*100/qs.length)+"%";document.getElementById("warn").textContent="";}
  function tier(p){
    if(p>=90)return ["מצוין!","שליטה מצוינת בחומר של הפרק."];
    if(p>=75)return ["טוב מאוד","רוב החומר ברור לך. כדאי לחדד את הנקודות שפספסת."];
    if(p>=56)return ["סביר","יש בסיס, אבל כדאי לחזור על כמה נושאים לפני שממשיכים."];
    return ["כדאי לחזור על החומר","אל תתייאשו: קראו שוב את הדוגמאות והסברים של הפרק, ונסו שוב."];
  }

  // בניית טקסט לג'מיני: כל השאלות, התשובות של התלמיד והמשוב, ובקשה ללמידה מותאמת אישית
  function geminiPrompt(score,per){
    var L=[];
    L.push("אני תלמיד בכיתה י\"א ולומד יסודות מדעי המחשב בשפת C#, לפי תכנית הבגרות של משרד החינוך.");
    L.push("פתרתי מבחן תרגול על פרק "+D.chapter+": "+D.title+". קיבלתי "+score+" תשובות נכונות מתוך "+qs.length+".");
    L.push("");
    L.push("תוצאות לפי נושא:");
    D.topics.forEach(function(name,i){L.push("- "+name+": "+per[i].ok+" מתוך "+per[i].n);});
    L.push("");
    L.push("השאלות, התשובה שלי והמשוב:");
    qs.forEach(function(q){
      var good=q.picked>=0&&q.opts[q.picked].ok, right="";
      q.opts.forEach(function(o){if(o.ok)right=o.t;});
      L.push("");
      L.push("שאלה "+(q.i+1)+" (נושא: "+D.topics[q.topic]+") - "+(good?"עניתי נכון":(q.picked<0?"לא עניתי":"טעיתי")));
      L.push(q.text);
      if(q.code){L.push("```csharp");L.push(q.code);L.push("```");}
      if(!good){
        L.push("התשובה שלי: "+(q.picked<0?"(לא עניתי)":q.opts[q.picked].t));
        L.push("התשובה הנכונה: "+right);
      }
      if(q.why){L.push("הסבר: "+q.why);}
    });
    L.push("");
    L.push("מה אני מבקש ממך:");
    L.push("1. תהיה המורה הפרטי שלי. לפי הטעויות שלי, הסבר בקצרה ובפשטות מה כנראה לא הבנתי.");
    L.push("2. תן לי תרגול מותאם אישית: שאלה אחת בכל פעם, בסגנון השאלות שלמעלה ובנושאים שבהם טעיתי. חכה לתשובה שלי לפני שאתה ממשיך.");
    L.push("3. אחרי כל תשובה שלי אמור אם צדקתי והסבר למה. אם טעיתי, תן רמז ותן לי לנסות שוב לפני שאתה מגלה את התשובה.");
    L.push("4. השתמש רק במה שנכלל בתכנית הבגרות: בלי אופרטור תנאי מקוצר, בלי += ודומיו, בלי switch, break או do-while. במחרוזות רק Length, גישה לתו לפי מקום, IndexOf ו-Contains. במחלקות פעולות Get ו-Set ולא מאפיינים.");
    L.push("5. אל תכתוב בשבילי פתרונות למשימות שאני צריך להגיש.");
    L.push("6. ענה בעברית, וכתוב קוד בשפת C#.");
    return L.join("\n");
  }
  function copyText(t){
    try{if(navigator.clipboard&&window.isSecureContext){return navigator.clipboard.writeText(t);}}catch(e){}
    return new Promise(function(ok,bad){
      var ta=document.createElement("textarea");ta.value=t;ta.setAttribute("readonly","");ta.style.position="fixed";ta.style.top="-1000px";
      document.body.appendChild(ta);ta.select();
      try{document.execCommand("copy")?ok():bad();}catch(e){bad();}
      document.body.removeChild(ta);
    });
  }
  function finish(){
    var a=answered();
    if(a<qs.length&&!warned){warned=true;
      var first=qs.filter(function(q){return q.picked<0;})[0];
      document.getElementById("warn").textContent="נותרו "+(qs.length-a)+" שאלות ללא תשובה, והן ייחשבו כלא נכונות. לחצו שוב על \"סיום ובדיקה\" כדי לסיים, או חזרו להשלים.";
      document.getElementById("q"+first.i).scrollIntoView({behavior:"smooth",block:"center"});return;}
    locked=true;document.getElementById("quiz").classList.add("locked");
    var score=0,per=D.topics.map(function(){return {ok:0,n:0};});
    qs.forEach(function(q){
      per[q.topic].n++;
      var card=document.getElementById("q"+q.i),why=card.querySelector(".why");
      var inputs=card.querySelectorAll("input");for(var z=0;z<inputs.length;z++){inputs[z].disabled=true;}
      var good=q.picked>=0&&q.opts[q.picked].ok;
      if(good){score++;per[q.topic].ok++;card.classList.add("right");}
      else{card.classList.add(q.picked<0?"skipped":"wrong");}
      q.opts.forEach(function(o,k){var el=document.getElementById("o"+q.i+"_"+k);el.classList.remove("sel");
        if(o.ok)el.classList.add("good");else if(k===q.picked)el.classList.add("miss");});
      why.style.display="block";
      why.innerHTML=(good?"<b>נכון.</b> ":(q.picked<0?"<b>לא נענתה.</b> ":"<b>לא נכון.</b> "))+fmt(q.why||"");
    });
    var pct=Math.round(score*100/qs.length),t=tier(pct);
    var good=[],todo=[],rows="";
    D.topics.forEach(function(name,i){
      var p=per[i];
      rows+="<div class=\"topicrow\"><span class=\"nm\">"+esc(name)+"</span><span class=\"tr\"><i style=\"width:"+(p.ok*100/p.n)+"%\"></i></span><span class=\"ct\">"+p.ok+"/"+p.n+"</span></div>";
      if(p.ok>=2){good.push(esc(name)+" ("+p.ok+" מתוך "+p.n+")");}
      if(p.ok===2){todo.push(esc(name)+": כדאי לחדד, טעיתם בשאלה אחת");}
      else if(p.ok<2){todo.push(esc(name)+": כדאי לחזור על הנושא ("+p.ok+" מתוך "+p.n+")");}
    });
    var h="<div class=\"score\"><div class=\"big\"><b>"+pct+"</b><span>ציון לימודי, "+score+" תשובות נכונות מתוך "+qs.length+"</span></div>";
    h+="<div class=\"tier\">"+t[0]+"</div><div>"+t[1]+"</div>";
    h+="<p class=\"small\">הציון הזה נועד ללמידה בלבד. הוא אינו נשמר ואינו נשלח לאף מקום.</p>";
    h+="<div style=\"margin-top:12px\">"+rows+"</div>";
    h+="<div class=\"fb\"><section class=\"good\"><h3>מה היה טוב</h3>"+(good.length?"<ul><li>"+good.join("</li><li>")+"</li></ul>":"<div>עדיין אין נושא שנענה היטב. זו הזדמנות להתחיל מהדוגמאות.</div>")+"</section>";
    h+="<section class=\"todo\"><h3>על מה כדאי לחזור</h3>"+(todo.length?"<ul><li>"+todo.join("</li><li>")+"</li></ul><div class=\"small\" style=\"margin-top:6px\">הסברים לכל שאלה מופיעים מתחת לשאלות. אפשר גם לחזור ל<a href=\""+D.chapterUrl+"\">דוגמאות הקוד של הפרק</a>.</div>":"<div>אין נושא שדורש חזרה. כל הכבוד!</div>")+"</section></div>";
    h+="<div class=\"actions\"><button id=\"again\">נסו שוב (שאלות בסדר אחר)</button><a class=\"btn ghost\" href=\"../index.html#ch"+D.chapter+"\">חזרה לפרק</a></div>";
    h+="<section class=\"gem\"><h3>להמשיך ללמוד עם Gemini</h3><div>לחיצה על הכפתור מעתיקה את כל השאלות, התשובות שלכם והמשוב, ופותחת את Gemini. שם הדביקו ושלחו: במחשב בעזרת <bdi dir=\"ltr\">Ctrl+V</bdi>, ובטלפון בלחיצה ארוכה ואז \"הדבקה\". Gemini יתרגל אתכם בדיוק בנושאים שבהם טעיתם.</div>";
    h+="<div class=\"small\">ודאו שאתם מחוברים ל-Gemini עם חשבון בית הספר שלכם.</div>";
    h+="<div class=\"actions\"><button id=\"gemini\">העתקה ופתיחת Gemini</button></div><div id=\"gemmsg\" class=\"small\"></div><textarea id=\"gemtxt\" readonly style=\"display:none\"></textarea></section></div>";
    var r=document.getElementById("result");r.innerHTML=h;r.style.display="block";
    document.getElementById("fin").style.display="none";document.getElementById("warn").textContent="";
    document.getElementById("again").onclick=function(){location.reload();};
    var gtext=geminiPrompt(score,per);
    document.getElementById("gemini").onclick=function(){
      var msg=document.getElementById("gemmsg"),ta=document.getElementById("gemtxt");
      copyText(gtext).then(function(){
        msg.textContent="הטקסט הועתק. עברו לחלון של Gemini, הדביקו ושלחו.";
      },function(){
        msg.textContent="ההעתקה האוטומטית לא הצליחה. סמנו את הטקסט בתיבה, העתיקו אותו והדביקו ב-Gemini.";
        ta.value=gtext;ta.style.display="block";ta.select();
      });
      window.open("https://gemini.google.com/app","_blank","noopener");
    };
    r.scrollIntoView({behavior:"smooth",block:"start"});
  }
  render();progress();
  document.getElementById("fin").onclick=finish;
})();
