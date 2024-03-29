'use strict'

var ISNPS = {

    IsJSON: function (value) {
        try {
            JSON.parse(value);
        } catch (e) {
            return false;
        }
        return true;
    },
    ParseJSON: function (value) {
        try {
            var parsed = JSON.parse(value);
            return parsed;
        } catch (e) {

            var json = {
                parsed: value,
                e: e,
            };
            return json;
        }
        return value;
    },
    //������� ���������� ���� 
    HideModals: function () {
        $('#lgModal,#xlModal').modal('hide');
    },

    // ����� ���������� ���� c id lgModal
    LargeModal: function () {
        // ���������� ��������� ����
        var myModal = new bootstrap.Modal(document.getElementById('lgModal'), {
            //���� �� ����� ����������� ��� ������� �� ������� "Escape"
            keyboard: false
        });
        //����������� ��������� ���������� ���� ����� �������� � ��������
        myModal.toggle();

        //���������� ��������� ����.
        myModal.show();
    },
    ExtraLargeModal: function () {
        var myModal = new bootstrap.Modal(document.getElementById('xlModal'), {
            keyboard: false
        });
        myModal.toggle();
        myModal.show();
    },

    ajaxGET: function (url, modal, gridId) {
        $.ajax({
            url: url,
            cache: false,
            type: "GET",
            dataType: "html",
            statusCode: {
                302: function (data) {
                    window.location.href = '/Account/Logout/';
                }
            },
            success: function (result) {
                ISNPS.GETResponse(result, modal, gridId);
            }
        });

    },
    GETResponse: function (result, modal, gridId) {
        //���� json ������
        if (ISNPS.IsJSON(result)) {
            result = ISNPS.ParseJSON(result);
        }
       //���� ����� �� � json �� ������������ ������ �� ������������ ���������
       //��������� ���� ��������� ���� ������� ��������� ������
        else {
            if (modal != null) {
                $(modal).html(result);
            }
        }
        // ������������� ������ �� ��������� ������ devexpress c gridId
        if (gridId) {
            var table = $("#" + gridId).dxDataGrid("instance");
            if (ISNPS.isNotEmpty(table)) {
                $("#" + gridId).dxDataGrid("getDataSource").reload();
            }
        }
    },

    ajaxPOST: function (url, form, modal, gridId) {
        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            dataType: "html",
            data: form.serialize(),
            statusCode: {
                302: function (data) {
                    window.location.href = '/Account/Logout/';
                }
            },
            success: function (result) {
                ISNPS.POSTResponse(result, modal, gridId);
            }
        });
    },

    POSTResponse: function (result, modal, gridId)
    {
        if (ISNPS.IsJSON(result))
        {
            result = ISNPS.ParseJSON(result);
            if (modal)
            {
                ISNPS.HideModals();
            }
            if (gridId)
            {
                $("#" + gridId).dxDataGrid("getDataSource").reload();
            }
            if (result.ShowToast) {
                ShowToast('success', result.Message);
            }
            return result;
        }
        else 
            if (modal != null)
            {
                $(modal).html(result);           
            }
            else $("form[name='changePassword']").html(result);
    },

    DrawPartialView: function (url, divId) {
        $.ajax({
            url: url,
            cache: false,
            type: "GET",
            dataType: "html",
            statusCode: {
                302: function (data) {
                    window.location.href = '/Account/Logout/';
                }
            },
            success: function (result, e) {
                //���� �� ������ ������� ����������� �� ������ � _Layout
                if (divId == null) {
                    $('#bodyContent').html(result);
                    }
                
                //� ��������� ������ ����������� ��������� ��������
                else 
                {
                    $('#' + divId).html(result);
                }

            },
        });
    },

    DrawPartialModal: function (url, modalId) {

        if (modalId == "xlModalBody") {
            ISNPS.ExtraLargeModal();
        }
        else if (modalId == "lgModalBody") {
            modalId
            ISNPS.LargeModal();
        }
        $.ajax({
            url: url,
            cache: false,
            type: "GET",
            dataType: "html",

            statusCode: {
                302: function (data) {
                    window.location.href = '/Account/Logout/';
                }
            },
            success: function (result) {
                if (!ISNPS.IsJSON(result)) {
                    //������� html �������� � ��������� ����
                    $('#' + modalId).html(result);
                }
            }
        });
    },

    ajaxCultureGET: function (url) {
        $.ajax({
            url: url,
            cache: false,
            type: "GET",
            dataType: "html",
            statusCode: {
                302: function (data) {
                    window.location.href = '/Account/Logout/';
                }
            },
            success: function (result) {
                ISNPS.GETCultureResponse(result);
            }
        });

    },
    GETCultureResponse: function (result)
    {
        var replacedText = ISNPS.IsJSON(result);
        if (ISNPS.IsJSON(result))
        {
            result = ISNPS.ParseJSON(result);        
                if (result.Result == 1)
                {
                    //���������� ���� �������� URL
                    var drawUrl = window.location.pathname;
                    if (drawUrl == "/Account/LockScreen")
                    {
                        window.location.href = '/Account/LockScreen';
                    }
                    else
                    {
                        if (drawUrl == "/Account/Login")
                        {
                            //������������ ��������
                            window.location.reload();
                        }
                        else
                        {
                            //�������� ��� ��������� ������� "/" � drawUrl �� ������ "_" 
                            var replacedText = drawUrl.replace(/\//g, "_");
                            //��������������� �� ����� URL
                            window.location.href = "/Redirect/Home/Home/" + replacedText;
                        }
                    }           
                }
        }
    },

}