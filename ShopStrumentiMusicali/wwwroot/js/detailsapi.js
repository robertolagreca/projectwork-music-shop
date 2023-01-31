
//AVVISO ANCORA IN BOZZA. DA CONTROLLARE NOMI VARIABILI.
const id = window.location.href.substring(window.location.href.lastIndexOf('/') + 1);
axios.get("/Home/Details/id).then((res) => {
                
                console.log('strumento visualizzato', instrument);


                document.getElementById('instrument_container').innerHTML +=
                    `
                        <div class="col-12 col-md-4 p-2">
                              <div class="card post h-100">
                                    <img src="${instrument.imageUrl}" class="card-img-top" alt="strumento">
                                    <div class="card-body">
                                    <h5 class="card-title">${instrument.name}</h5>
                                            <p class="card-text">${instrument.description}</p>
                                            <p class="card-text">${instrument.price}</p>
                                    </div>
                            </div>
                        </div>
                    `;

            });