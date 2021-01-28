$(document).ready(async () => {
    //$("#btn-salvar-produto").click(cadastrarProduto);
    this.get();
    this.getProducts();
    this.reset();
});

const defaultHeaders = {
    Accept: "application/json",
    "Content-Type": "application/json",

};

async function submit() {
    var valida = this.validar();
    if (!valida) return;

    var send = {};
    send.DAT_MES = parseInt($('#mounth').val());
    send.DAT_ANO = parseInt($('#year').val());
    send.COD_COSIF = $('#cosif').val();
    send.VAL_VALOR = parseFloat($('#value').val());
    send.DES_DESCRICAO = $('#description').val();
    send.COD_PRODUTO = $("#product").val();
    //send.NUM_LANCAMENTO = 01;
    //send.DAT_MOVIMENTO = '2020-01-28 05:17:12';
    //send.COD_USUARIO = '1234';

    try {
        const rawResponse = await fetch("http://localhost:1269/MovimentosManuais", {
            method: "POST",
            headers: defaultHeaders,
            body: JSON.stringify(send),
        });
        const response = await rawResponse.json();
        console.log(response);
        if (!response.COD_PRODUTO) {
            throw new Error(response.title);
            return;
        }
        this.reset();
        location.reload();
    } catch (err) {
        alert(err.message || err);
    }
}


async function get() {
    const rawResponse = await fetch("http://localhost:1269/MovimentosManuais", {
        method: "GET",
        headers: defaultHeaders,
        //body: JSON.stringify({
        //    id: produtoSelecionado.workFlowSemanaProdutoId,
        //    produtoId: produtoSelecionado.workFlowProdutoId,
        //    semanaId: novaSemanaId,
        //}),
    });
    const response = await rawResponse.json();

    this.trContent = $("#trContent");

    const toRender = response.map((res) => this.getContent(res));
    toRender.forEach((content) => this.trContent.append(content));
}

function getContent(item) {
    const { DAT_MES, DAT_ANO, NUM_LANCAMENTO, COD_PRODUTO, DES_DESCRICAO, VAL_VALOR } = item;

    return `<tr>
                    <td>${DAT_MES}</td>
                    <td>${DAT_ANO}</td>
                    <td>${COD_PRODUTO}</td>
                    <td>${NUM_LANCAMENTO}</td>
                    <td>${DES_DESCRICAO}</td>
                    <td>${VAL_VALOR}</td>
            </tr>
    `;
}


async function getProducts() {
    const rawResponse = await fetch("http://localhost:1269/produtos", {
        method: "GET",
        headers: defaultHeaders,
    });
    const response = await rawResponse.json();

    this.product = $("#product");
    this.product.html("<option value=''>-- Selecione --</option>");

    const toRender = response.map((res) => this.getProductsValues(res));
    toRender.forEach((content) => this.product.append(content));
    this.product.val('');
}


function getProductsValues(item) {
    const { COD_PRODUTO, DES_PRODUTO } = item;

    return `<option value='${COD_PRODUTO}'>${DES_PRODUTO}</option>  `;
}

async function getProductsCosifs(codProduct) {
    if (codProduct != '') {
        console.log(codProduct);
        const rawResponse = await fetch("http://localhost:1269/produtoscosif/" + codProduct, {
            method: "GET",
            headers: defaultHeaders,
        });
        const response = await rawResponse.json();

        this.productcosif = $("#cosif");
        this.productcosif.html("<option value=''>-- Selecione --</option>");

        const toRender = response.map((res) => this.getProductsCosifsValues(res));
        toRender.forEach((content) => this.productcosif.append(content));
        this.productcosif.val('');
    }
}


function getProductsCosifsValues(item) {
    const { COD_COSIF, COD_CLASSIFICACAO } = item;

    return `<option value='${COD_COSIF}'>${COD_CLASSIFICACAO}</option>  `;
}

