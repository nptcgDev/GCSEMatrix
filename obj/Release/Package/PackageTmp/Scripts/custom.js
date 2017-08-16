function showDiv() {
    $('.summary').css('display', 'block');
    $('.form-control').prop('disabled', true);
    $('#gcse-results').show();
    $('#predict-grade').hide();
    $('#signature').show();
    $('#amend').show();
}
function editGrades() {
    $(".form-control").removeAttr('disabled');
    $('#predict-grade').show();
    $('#amend').hide();
}

function print() {

    $('#amend').hide();
    $('#print').hide();

}