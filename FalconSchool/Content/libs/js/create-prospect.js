$(document).ready(function () {
    $("#DoB").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: '-15y',
        yearRange: '1995:+nn',
        maxDate: '-3y',
        showOn: 'button',
        buttonText: 'Show Date',
        buttonImageOnly: true,
        buttonImage: 'http://jqueryui.com/resources/demos/datepicker/images/calendar.gif',
    });
});