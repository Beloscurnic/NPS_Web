function onSubmitClick(e) {
	e.event.preventDefault();
	var $form = $('form[name="changePassword"]');
	var url = $form.attr('action');
	var modal = null;
	var gridId = null;
	ISNPS.ajaxPOST(url, $form, modal, gridId)
}

