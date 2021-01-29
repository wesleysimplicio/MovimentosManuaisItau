// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function newForm() {
    this.allDisabledOff();
}

function validar() {
    var campos_focus = new Array();
    var i = 0;

    $('.text-danger').text('');

    if ($('#mounth').val() === '') {
        $('#mounth').after("<div id='mounth_error' class='text-danger'>Preencha este campo.</div>");
        $('#mounth').attr('style', 'border:1px solid red;');
        i++;
    } else if ($('#mounth').val() > 12) {
        $('#mounth').after("<div id='mounth_error' class='text-danger'>Preencha mês válido.</div>");
        $('#mounth').attr('style', 'border:1px solid red;');
    } else {
        $('#mounth_error').remove();
        $('#mounth').attr('style', 'border:1px solid #CCC;');
    }

    if ($('#year').val() === '') {

        $('#year').after("<div id='year_error' class='text-danger'>Preencha este campo.</div>");
        $('#year').attr('style', 'border:1px solid red;');
        i++;
    } else {
        $('#year_error').remove();
        $('#year').attr('style', 'border:1px solid #CCC;');
    }

    if ($('#cosif').val() === '') {

        $('#cosif').after("<div id='cosif_error' class='text-danger'>Preencha este campo.</div>");
        $('#cosif').attr('style', 'border:1px solid red;');
        i++;
    } else {
        $('#cosif_error').remove();
        $('#cosif').attr('style', 'border:1px solid #CCC;');
    }

    if ($('#value').val() === '') {

        $('#value').after("<div id='value_error' class='text-danger'>Preencha este campo.</div>");
        $('#value').attr('style', 'border:1px solid red;');
        i++;
    } else {
        $('#value_error').remove();
        $('#value').attr('style', 'border:1px solid #CCC;');
    }

    if ($('#description').val() === '') {

        $('#description').after("<div id='description_error' class='text-danger'>Preencha este campo.</div>");
        $('#description').attr('style', 'border:1px solid red;');
        i++;
    } else {
        $('#description_error').remove();
        $('#description').attr('style', 'border:1px solid #CCC;');
    }

    if ($('#product').val() === '') {

        $('#product').after("<div id='product_error' class='text-danger'>Preencha este campo.</div>");
        $('#product').attr('style', 'border:1px solid red;');
        i++;
    } else {
        $('#product_error').remove();
        $('#product').attr('style', 'border:1px solid #CCC;');
    }

    if ($('.text-danger').text() == '') {
        return true;
    } else {
        $(campos_focus[0]).focus();
        return false;
    }
}


function reset() {
    this.allDisabledOn();
    $('#mounth').val('');
    $('#year').val('');
    $('#cosif').val('');
    $('#value').val('');
    $('#description').val('');
    $("#product").html("<option value='' selected>-- Selecione --</option>");
    $("#cosif").html("<option value='' selected>-- Selecione --</option>");
    $("#product").val('');
    $("#cosif").val('');
    $('#mounth_error').remove();
    $('#mounth').attr('style', 'border:1px solid #CCC;');
    $('#year_error').remove();
    $('#year').attr('style', 'border:1px solid #CCC;');
    $('#cosif_error').remove();
    $('#cosif').attr('style', 'border:1px solid #CCC;');
    $('#value_error').remove();
    $('#value').attr('style', 'border:1px solid #CCC;');
    $('#description_error').remove();
    $('#description').attr('style', 'border:1px solid #CCC;');
    $('#product_error').remove();
    $('#product').attr('style', 'border:1px solid #CCC;');
}

function allDisabledOn() {
    $('#mounth').attr('disabled', 'disabled');
    $('#year').attr('disabled', 'disabled');
    $('#product').attr('disabled', 'disabled');
    $('#cosif').attr('disabled', 'disabled');
    $('#value').attr('disabled', 'disabled');
    $('#description').attr('disabled', 'disabled');

    $('#btnClear').attr('disabled', 'disabled');
    $('#btnClear').addClass('disabled');

    $('#btnSubmit').attr('disabled', 'disabled');
    $('#btnSubmit').addClass('disabled');

    $('#btnNew').removeAttr('disabled');
    $('#btnNew').removeClass('disabled');
}

function allDisabledOff() {
    $('#mounth').removeAttr('disabled');
    $('#year').removeAttr('disabled');
    $('#product').removeAttr('disabled');
    $('#cosif').removeAttr('disabled');
    $('#value').removeAttr('disabled');
    $('#description').removeAttr('disabled');

    $('#btnNew').attr('disabled', 'disabled');
    $('#btnNew').addClass('disabled');

    $('#btnClear').removeAttr('disabled');
    $('#btnClear').removeClass('disabled');

    $('#btnSubmit').removeAttr('disabled');
    $('#btnSubmit').removeClass('disabled');
}