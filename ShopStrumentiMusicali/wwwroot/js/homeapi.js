//AVVISO ANCORA IN BOZZA. DA CONTROLLARE NOMI VARIABILI.

//API per la searchbar

document.getElementById('input_search').addEventListener('keyup', searchInstruments);

function searchInstruments() {
    let stringOfResearch = document.getElementById('input_search').value;
    loadInstruments(stringOfResearch);
}

function loadInstruments(searchString) {


    axios.get('/api/NOME CONTROLLER API', {
        params: {
            search: searchString
        }
    }
    ).then((res) => {

        console.log('risultato ok');
        console.log(res);


        if (res.data.length > 0) {
            document.getElementById('container_instruments').classList.remove('d-none');
            document.getElementById('container_no_instruments').classList.add('d-none');

            document.getElementById('container_instruments').innerHTML = '';

            res.data.forEach(instrument => {

                console.log('instrument: ', instrument);

                document.getElementById('container_instruments').innerHTML +=
                    `
                            <div class="col-12 col-md-4 p-2">
                                <div class="card post h-100">
                                <a href="/Home/Details/${instrument.id}">
                                    <img src="${instrument.imageUrl}" class="card-img-top" alt="strumento">
                                    <div class="card-body">
                                        <h5 class="card-title">${instrument.name}</h5>
                                        <p class="card-text">${instrument.description}</p>
                                        <p class="card-text">${instrument.price}</p>
                                    </div>
                                </a>
                                </div>
                            </div>
                            `;
            });

        } else {

            document.getElementById('container_no_instruments').classList.remove('d-none');
            document.getElementById('container_instruments').classList.add('d-none');
        }

    }).catch((error) => {
        console.log(error);
    });

    }

//API per acquistare

function sendInstrument(e){
    e.preventDefault();

    axios.get('/api/NOME CONTROLLER API', {

        let instrumentToBeBought {
            "name" : //Inserirre getElementBy,
            "imageUrl" : //Inserirre getElementBy, 
            "description" : //Inserirre getElementBy,
            "price" : //Inserirre getElementBy,
            "userID" : //Inserirre getElementBy,
            "ordineID": //Inserirre getElementBy
        }}
        ).then((response) => {
            console.log('strumento pronto per essere acquistato');
            window.location.href='' //PERCORSO CHE PORTA ALLA PAGINA COMPRA.

        }
        ).catch((error) => {
        console.log(error);
    });

    }
