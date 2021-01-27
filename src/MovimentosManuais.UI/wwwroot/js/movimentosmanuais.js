$(document).ready(async() => {
    //$("#btn-salvar-produto").click(cadastrarProduto);
    this.get();
});

const defaultHeaders = {
    Accept: "application/json",
    "Content-Type": "application/pjson",

};
async function get() {
    const rawResponse = await fetch("http://localhost:1269/produtos", {
        method: "GET",
        headers: defaultHeaders,
        //body: JSON.stringify({
        //    id: produtoSelecionado.workFlowSemanaProdutoId,
        //    produtoId: produtoSelecionado.workFlowProdutoId,
        //    semanaId: novaSemanaId,
        //}),
    });
    const response = await rawResponse.json();
    console.log(response);
}

function submit() {
    alert('submit');
}

function newForm() {
    this.allDisabledOff();
}

function reset() {
    this.allDisabledOn();
    $('#mounth').val('');
    $('#year').val('');
    $('#product').val('');
    $('#cosif').val('');
    $('#value').val('');
    $('#description').val('');
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