mergeInto(LibraryManager.library, {
  addData:function(jsonData){
    var jsonObj = JSON.parse(Pointer_stringify(jsonData));
      addJsonData(jsonObj);
  },
  downloadData:function(){
    downloadJsonData();
  },
  StartMist: function() { 
    var messageString = "StartMist!! postmessage test!";
    window.postMessage(messageString, "*");
  },
});