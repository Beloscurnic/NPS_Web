$(document).ready(function () {
    ISNPS.DrawPartialView("/ProfileInfo/Get_ChangePassword");
})

function onSubmitClick(e) {
	e.event.preventDefault();
	var $form = $('form[name="changePassword"]');
	var url = $form.attr('action');
	ISAdmin.ajaxPOST(url, $form, modal, gridId);
}
