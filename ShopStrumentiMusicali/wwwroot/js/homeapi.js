//AVVISO ANCORA IN BOZZA. DA CONTROLLARE NOMI VARIABILI.


//Per visualizzare per ogni prodotto su index

//AVVISO ANCORA IN BOZZA. DA CONTROLLARE NOMI VARIABILI.

debugger;
//function loadInstruments() {
axios.get("/api/InstrumentApi/").then((res) => {

    let instrument = res.data;
    console.log('strumento visualizzato', instrument);

    if (res.data.length == 0) {

        document.querySelector('.js_no_instrument').classList.remove('d-none');
        document.querySelector('.js_instrument_table').classList.add('d-none');


        document.querySelector('.js_instrument_table').classList.remove('d-none');
        document.querySelector('.js_no_instrument').classList.add('d-none');

        document.querySelector('.js_instrument_table').innerHTML = '';

        instrument.forEach(instrument => {

            console.log('strumento', instrument);

            document.getElementById('js_instrument_table').innerHTML +=
                `
                        <div class="col-12 col-md-4 p-2">
                              <div class="card post h-100">
                                    <img src="${instrument.imageUrl}" class="card-img-top" alt="strumento">
                                    <div class="card-body">
                                    <h5 class="card-title">${instrument.name}</h5>
                                            <p class="card-text">${instrument.description}</p>
                                            <p class="card-text">${instrument.price}</p>
                                            <a href="#" class="btn btn-primary">Dettagli</a>
                                            <a href="#" class="btn btn-primary">Compra</a>
                                    </div>
                            </div>
                        </div>
                    `;

        });
    } else {
        document.getElementById('js_no_instrument').classList.remove('d-none');
        document.getElementById('js_instrument_table').classList.add('d-none');
    }
});
//}