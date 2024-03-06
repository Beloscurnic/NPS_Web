var time = new Date().getTime();
var page = "";
$(document.body).bind("mousemove keypress", function (e) {
	page = e.target.ownerDocument.location.pathname;

	time = new Date().getTime();
});

function refresh() {
	if (page == "/Account/Login") {
		return;
	}
	else {
		var timeNow = new Date().getTime();
		if (timeNow - time >= 1200000)
			window.location.href = '/Account/LockScreen/';
		else
			setTimeout(refresh, 60000);
	}
}

setTimeout(refresh, 60000);