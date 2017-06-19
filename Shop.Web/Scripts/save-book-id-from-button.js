$(document).on("click", ".open-AddToCartModal", function () {
    var myBookId = $(this).data('id');
    $(".modal-body #bookId").val(myBookId);
    $('#addBookDialog').modal('show');
});
