
var lgModal = document.getElementById('lgModal');
var xlModal = document.getElementById('xlModal');

// возрат спинера после его удаления для вывода данных тем саммым происходит востановление в исходное состояния

var html = '<div id="spinner-content" class="d-flex justify-content-center">' +
    '<div class="" name="Growing-Spinners">' +
    '<div class="spinner-grow text-primary" role = "status" style="height:3rem;width:3rem;" >' +
    '<span class="sr-only">Loading...</span>' +
    '</div >' +
    '<div class="spinner-grow text-secondary" role="status" style="height:3rem;width:3rem;">' +
    ' <span class="sr-only">Loading...</span>' +
    '</div>' +
    '<div class="spinner-grow text-success" role="status" style="height:3rem;width:3rem;">' +
    '<span class="sr-only">Loading...</span>' +
    '</div>' +
    '<div class="spinner-grow text-danger" role="status"style="height:3rem;width:3rem;">' +
    '<span class="sr-only">Loading...</span>' +
    '</div>' +
    '<div class="spinner-grow text-warning" role="status" style="height:3rem;width:3rem;">' +
    '<span class="sr-only">Loading...</span>' +
    '</div>' +
    '<div class="spinner-grow text-info" role="status" style="height:3rem;width:3rem;">' +
    '<span class="sr-only">Loading...</span>' +
    '</div>' +
    '</div >' +
    '</div >';

    //методы для закрытия модального окна с его востоновлением 
    //обработчика события 'hidden.bs.modal' будет выполнен каждый раз, 
    //когда пользователь закрывает модальное окно Bootstrap
lgModal.addEventListener('hidden.bs.modal', function () {
    //удаляет все данные, связанные с элементом, на котором сработало событие
    $(this).removeData();

    //устанавливает HTML-содержимое элемента с идентификатором lgModalBody.
    $("#lgModalBody").html(html);

})

xlModal.addEventListener('hidden.bs.modal', function () {
    $(this).removeData();
    $("#xlModalBody").html(html);
})

//отображения всплывающих уведомлений библиотеки Toastr

//id указывает на тип уведомления, которое должно быть отображено.
//Это может быть 'success', 'info', 'warning' или 'error'.

//Параметр text содержит текст уведомления.
function ShowToast(id, text) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr[id](text);
}

//отображения всплывающего уведомления определенного типа "danger"
//Параметр message содержит текст сообщения
function showDangerAlert(message) {
    toastr["danger"](message);
}

// скрывает модальные окна указываем им свойства hide
function closeModalClick(e) {
    $('#lgModal,#xlModal').modal('hide');
}
