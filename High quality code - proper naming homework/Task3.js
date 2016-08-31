function onClick( ev, arguments) {
  var main= window,
      browser = main.navigator.appCodeName,
      isMozilla = browser=="Mozilla";
  if(isMozilla) {
    alert("Yes");
  } else {
    alert("No");
  }
}