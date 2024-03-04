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
    //скрытие модального окна 
    HideModals: function () {
        $('#lgModal,#xlModal').modal('hide');
    },

    // вызов модального окна c id lgModal
    LargeModal: function () {
        // определяем модальное окно
        var myModal = new bootstrap.Modal(document.getElementById('lgModal'), {
            //окно не будет закрываться при нажатии на клавишу "Escape"
            keyboard: false
        });
        //переключает состояние модального окна между открытым и закрытым
        myModal.toggle();

        //отображает модальное окно.
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
        //если json парсим
        if (ISNPS.IsJSON(result)) {
            result = ISNPS.ParseJSON(result);
        }
       //если ответ не в json то отправляемые данные не соотвествуют валидации
       //ворзащаем тоже модальное окно включил валидацию данных
        else {
            if (modal != null) {
                $(modal).html(result);
            }
        }
        // перезагружает данные из источника данных devexpress c gridId
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

    POSTResponse: function (result, modal, gridId) {
        if (ISNPS.IsJSON(result))
        {
            result = ISNPS.ParseJSON(result);
                ISNPS.HideModals();       
            if (gridId) {
                $("#" + gridId).dxDataGrid("getDataSource").reload();
            }
        }
        else 
            if (modal != null)
            {
                $(modal).html(result);           
            }
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
                //если не указан элемент перерисовки то меняем в _Layout
                if (divId == null) {
                    $('#bodyContent').html(result);
                    }
                
                //в противном случае перерисовка указаного элемента
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
                    //вставка html разметки в модальное окно
                    $('#' + modalId).html(result);
                }
            }
        });
    },

}