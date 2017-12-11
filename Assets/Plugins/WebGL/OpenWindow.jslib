mergeInto(LibraryManager.library, {
	OpenWindow: function(urlPtr) {
		var url = Pointer_stringify(urlPtr);
		var F = 0;
		if (screen.height > 500) {
			F = Math.round((screen.height / 2) - (250));
		}
		window.open(url,
		'intent',
		'left='+Math.round((screen.width/2)-(250))+',top='+F+
		',width=500,height=260,personalbar=no,toolbar=no,resizable=no,scrollbars=yes');
	}

});
