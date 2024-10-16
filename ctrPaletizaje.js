angular.module('starter.controllersPaletizaje', [])

.controller('ctrStockAlmacen', function ($scope, $routeParams, $rootScope) {
    $('#StockAlmacen').addClass('animated ' + $routeParams.animacion);
    $rootScope.preloadMsg = "Procesando datos...";
    $rootScope.verLoading_(true, "Procesando datos...");
    $rootScope.preloadMsg = "Procesando datos...";
    $scope.ctrVerVentanaSelect = 0;
    $rootScope.datosPaletiza = {};
    $scope.idxP = 0;
    $scope.stockVisible = { selA: 'block', selO: 'none', selNC: 'none' };
    $scope.estadoTabSel = { ok: 'inactivo', obj: '', no: '' };

    $scope.agregaPalet = function (dato) {
            var css = '';
            var ESTADO_REC = ' ';
            switch (dato.ESTADO_REC) {
                case 'A':
                    css = 'ok';
                    ESTADO_REC = 'A';
                    break;
                case 'O':
                    css = 'obj';
                    ESTADO_REC = 'O';
                    break;
                case '':
                    css = 'sn';
                    ESTADO_REC = 'X';
                    break;
            }
            $rootScope.datosPaletiza.manual[$scope.idxP] = {
                idx: $scope.idxP,
                MATNR: dato.MATNR,//"FFA0303",
                WERKS: dato.WERKS,//"1050",
                LGORT: dato.LGORT,//"0001",
                CHARG: dato.CHARG,//"123",
                MEINS: dato.MEINS,//"CS",
                CLABS: dato.CLABS,//0,
                CINS: dato.CINS,//0,
                CSPEM: dato.CSPEM,//516,
                LIFNR: dato.LIFNR,//"0000007016",
                ESTADO_REC: ESTADO_REC,//"" A O '',
                css:css
            }
            $scope.idxP++;
        
    }

    $scope.cargarStockSelect = function () {
        var idxA = 0; $rootScope.datosPaletiza.selA = [];
        var idxO = 0; $rootScope.datosPaletiza.selO = [];
        var idxNC = 0; $rootScope.datosPaletiza.selNC = [];
        $rootScope.datosPaletiza.manual = [];
        angular.forEach($rootScope.STOCK_MCHB, function (value, key) {
            if ('A' == value.ESTADO_REC) {
                $rootScope.datosPaletiza.selA[idxA] = {
                    idx: idxA,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    seleccionado: 'false'
                };
                idxA++;
            }
            if ('O' == value.ESTADO_REC) {
                $rootScope.datosPaletiza.selO[idxO] = {
                    idx: idxO,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    seleccionado: 'false'
                }
                idxO++;
            }
            if ('' == value.ESTADO_REC) {
                $rootScope.datosPaletiza.selNC[idxNC] = {
                    idx: idxNC,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    seleccionado: false
                }
                idxNC++;
            }
        });
        $rootScope.verLoading_(false, "Procesando datos...");
    }

    $scope.cargarStockSelect();

    $scope.verVentanaSelect1 = function () {
        $('#btnAlamcenSelect').removeClass('inactivo');
        $('#VentanStock').hide();
        $('#VentanaSelect').removeClass('animated fadeOutLeft');
        $('#VentanaSelect').show();
        $('#VentanaSelect').addClass('animated fadeInLeft');
        $('#btnAlmacenStock').addClass('inactivo');
        $scope.ctrVerVentanaSelect = 0;
    }

    $scope.verVentanaSelect2 = function () {
        $('#btnAlmacenStock').removeClass('inactivo');
        $('#VentanaSelect').hide();
        $('#VentanStock').removeClass('animated fadeOutLeft');
        $('#VentanStock').show();
        $('#VentanStock').addClass('animated fadeInLeft');
        $('#btnAlamcenSelect').addClass('inactivo');
        $scope.ctrVerVentanaSelect = 1;

       // console.log($rootScope.datosPaletiza)

    }

    $scope.verVentanaSelect1();


    $scope.paletizajeIngreso = function () {
        var existe = 0;
        angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
            if (angular.uppercase($scope.inSelLotesManual) == value.CHARG) {
                existe = 1
            }
        });

        if (existe == 0) {
            var busqueda = 0;
            angular.forEach($rootScope.STOCK_MCHB, function (value, key) {
                if (angular.uppercase($scope.inSelLotesManual) == value.CHARG) {
                    $scope.agregaPalet(value);
                    busqueda = 1;
                }
            });
            if (busqueda == 0) {
                $rootScope.mostrarAlerta(true, 'Error', 'Lote:' + angular.uppercase($scope.inSelLotesManual) + ' no encontrado.');
            }
            $scope.inSelLotesManual = '';
        } else {
            $rootScope.mostrarAlerta(true, 'Advertencia', 'Lote:' + angular.uppercase($scope.inSelLotesManual) + ' ta se encuentra agregado.');
        }
    }

    $scope.selPaletizaQuitar = function (idx) {
        var auxidx = 0;
        $scope.datosPaletizaAux = [];
        $scope.datosPaletizaAux = $rootScope.datosPaletiza.manual;
        $scope.datosPaletiza.manual = [];
        angular.forEach($scope.datosPaletizaAux, function (value, key) {
            if (idx != value.idx) {
                    var css = '';
                    switch (value.ESTADO_REC) {
                        case 'A':
                            css = 'ok';
                            break;
                        case 'O':
                            css = 'obj';
                            break;
                        case '':
                            css = 'sn';
                            break;
                    }
                    $rootScope.datosPaletiza.manual[auxidx] = {
                        idx: auxidx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: value.ESTADO_REC,
                        inLotePaletizar: value.inLotePaletizar
                    }
                auxidx++;
            }
        });

    }
    
    $scope.limpiarCargaScaner = function () {
        $rootScope.datosPaletiza.manual = []
        $scope.idxP = 0;
    }

    $scope.verAlmacenOk = function () {
        $scope.stockVisible = { selA: 'block', selO: 'none', selNC: 'none' };
        $scope.estadoTabSel = { ok: 'inactivo', obj: '', no: '' };
    }

    $scope.verAlmacenObj = function () {
        $scope.stockVisible = { selA: 'none', selO: 'block', selNC: 'none' };
        $scope.estadoTabSel = { ok: '', obj: 'inactivo', no: '' };
    }
    $scope.verAlmacenNC = function () {
        $scope.stockVisible = { selA: 'none', selO: 'none', selNC: 'block' };
        $scope.estadoTabSel = { ok: '', obj: '', no: 'inactivo' };
    }

    $scope.filtroPaletiza = "TODOS";
    $scope.filtroPaletiza = "";


    $scope.continuarPelatizaPaso2=function(){
        if ($scope.ctrVerVentanaSelect == 0) { // lote manuel
            if (($rootScope.datosPaletiza.manual.length == 0) || ($rootScope.datosPaletiza.manual == null)) {
                $rootScope.mostrarAlerta(true, 'Error', 'Ingrese a lo menos un lote');
                return 0;
            }
        }
        if ($scope.ctrVerVentanaSelect == 1) { // lote stock filtro
            var idx = 0;
            $rootScope.datosPaletiza.manual = [];
            angular.forEach($rootScope.datosPaletiza.selA, function (value, key) {
                if (value.seleccionado == true) {
                    $rootScope.datosPaletiza.manual[idx] = {
                        idx: idx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: value.ESTADO_REC,
                        seleccionado: true,
                        inLotePaletizar: 0
                    }
                    idx++;
                }
            });
            angular.forEach($rootScope.datosPaletiza.selO, function (value, key) {
                if (value.seleccionado == true) {
                    $rootScope.datosPaletiza.manual[idx] = {
                        idx: idx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: value.ESTADO_REC,
                        seleccionado: true,
                        inLotePaletizar: 0
                    }
                    idx++;
                }
            });
            angular.forEach($rootScope.datosPaletiza.selNC, function (value, key) {
                if (value.seleccionado == true) {
                    $rootScope.datosPaletiza.manual[idx] = {
                        idx: idx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: 'X',
                        seleccionado: true,
                        inLotePaletizar: 0
                    }
                    idx++;
                }
            });
            if (idx == 0) {
                $rootScope.mostrarAlerta(true, 'Error', 'Ingrese a lo menos un lote');
                return 0;
            }
        }
        $scope.navegacionPagina('PROD_Contabilizar', 'fadeInRight', '');

    }

    $scope.codearPalet = function () {
        cordova.plugins.barcodeScanner.scan(
        function (result) {
            //alert(result.text)         
            document.getElementById('inSelLotesManual').value = result.text;
            $scope.inSelLotesManual = result.text;
            $scope.paletizajeIngreso();
        },
        function (error) {
            $rootScope.mostrarAlerta(true, "Error", "Scanning failed: " + error);
        }
      );
    }

})

.controller('ctrPROD_Contabilizar', function ($scope, $routeParams, $rootScope, dataFactory) {
    $('#ctrPROD_Contabilizar').addClass('animated ' + $routeParams.animacion);
    //console.log($rootScope.datosPaletiza)

    $scope.contabilizarPaletizaNOK = 'none';
    $scope.contabilizarPaletizaOK = 'none';
    $scope.contabilizarPaletizaNC = 'none';

    // llenado list box del popup
    $scope.selPaletizaTipiPalletOpciones = [];
    angular.forEach($rootScope.HU_DICCIONARIO.CONTENIDO, function (value, key) {
        $scope.selPaletizaTipiPalletOpciones.push({ value: value.TIPO_HU, name: value.TIPO_HU })
    });
    $scope.selPaletizaOtrasCOpciones = [];
    angular.forEach($rootScope.HU_DICCIONARIO.HU_GRP5, function (value, key) {
        $scope.selPaletizaOtrasCOpciones.push({ value: value.VEGR5, name: value.BEZEI })
    });


    $scope.mostrarPaletizaje = function (estado) {
        if (estado == true) {
            $scope.verPopPaletiza = "block";
            $scope.verBtnFin = "none";
            $scope.selPaletizaTipiPallet = { value: '', name: '-Sin Info-' };
            $scope.selPaletizaOtrasC = { value: '', name: 'Ninguno' };
        } else {
            $scope.verPopPaletiza = "none";
            $scope.verBtnFin = "block";
        }
    }
    // estableser oculto
    $scope.mostrarPaletizaje(false);

    $scope.mostrarRespuesta = function (estado) {
        if (estado == true) {
            $scope.verPopRespuesta = "block";
            //$scope.verBtnFin = "none";
        } else {
            $scope.verPopRespuesta = "none";
            //$scope.verBtnFin = "block";
        }
    }
    // estableser oculto
    $scope.mostrarRespuesta(false);

    $scope.finalizar = function () {
        $scope.mostrarRespuesta(false);
        $scope.navegacionPagina('menuPaletizar', 'fadeInRight', '');
    }


    angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
        if (value.ESTADO_REC == 'A') { $scope.contabilizarPaletizaOK = 'block'; }
        if (value.ESTADO_REC == 'O') { $scope.contabilizarPaletizaNOK = 'block'; }
        if (value.ESTADO_REC == 'X') { $scope.contabilizarPaletizaNC = 'block'; }
    });


    $scope.paletizarCajaEmbalada = function (grupo) {
        $scope.mostrarPaletizaje(true);
        switch (grupo) {
            case 'OK':
                $scope.pop = { css: 'ok', titulo: 'LOTES CORRECTOS', filtro: 'A', selPaletizaAlmacen: 'block' };
                break;
            case 'NOK':
                $scope.pop = { css: 'obj', titulo: 'LOTES OBJETADOS', filtro: 'O', selPaletizaAlmacen: 'block' };
                break;
            case 'NC':
                $scope.pop = { css: 'sn', titulo: 'LOTES SIN CLASIFICAR', filtro: 'X', selPaletizaAlmacen: 'block' };
                break; 
        }
        $scope.selPaletizaAlmacenIr = '';
        $scope.paletizaCajaNumeroPalet = '';
        $scope.selPaletizaTipiPallet = '';
        $scope.selPaletizaPCompleto = false;
        $scope.selPaletizaOtrasC = '';        
    }

    
    $scope.countVerifica = 0;
    $scope.countRealizado = 0;

    $scope.aceptaPaletizarCajaEmbalada = function () {
        if ($scope.paletizaCajaNumeroPalet == '') {
            $rootScope.mostrarAlerta(true, 'Advertencia!', 'Ingrese número de pallet');
            return 0;
        }


        $scope.mostrarPaletizaje(false);

        if ($rootScope.datoUsuario.idUsuario == "demo") {
            // stco OK
        } else {//$scope.pop.filtro
            // verificar stock disponible
            $scope.countVerifica = 0;
            $scope.countRealizado = 0;

            angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                if (value.ESTADO_REC == $scope.pop.filtro) {
                    $scope.countVerifica++;
                }
            });

            angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                if (value.ESTADO_REC == $scope.pop.filtro) {
                    var aux = $scope.verificaSaldo(value.CHARG, value.LGORT, value.idx);
                }


            });
 
        }
    }

    $scope.verificaSaldo = function (CHARG, LGORT, idx) {
        //console.log(CHARG +" -*- "+ LGORT)
        dataFactory.getDatos('STOCK_LOTES_TB', 'CHARG=' + CHARG + '&WERKS='+$rootScope.datoUsuario.acopio)
            .success(function (datos) {
                //console.log(datos.STOCK_MCHB.length)
                for (i = 0; i < datos.STOCK_MCHB.length; i++) {
                    if (datos.STOCK_MCHB[i].LGORT == LGORT) {
                        $rootScope.datosPaletiza.manual[idx].CSPEM = datos.STOCK_MCHB[i].CSPEM;
                        //??????????????????
                        $scope.estadoObteniendo();
                        return 0;
                    }
                }
            })
            .error(function (datos) {
                //$rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_PRODUCTORES');
            })
    }

    $scope.estadoObteniendo = function () {
        $scope.countRealizado++;
        //console.log($scope.countRealizado +'>='+ $scope.countVerifica)
        if ($scope.countRealizado >= $scope.countVerifica) {
            // se actualizaron todos los saldos de stock

           // console.log($rootScope.datosPaletiza.manual);

            var estado = 0;

            angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                if (value.ESTADO_REC == $scope.pop.filtro) {
                    if (value.inLotePaletizar <= value.CSPEM) {
                        //console.log("OK Si existen saldos en todos los lotes se procede envio XML");
                        //$scope.generaXML();
                    } else {
                        //console.log("ya no hay disponible");
                        estado = -1;
                    }

                }
            });

            if (estado == 0) {
                $scope.generaXML();
            } else {
                $scope.mostrarRespuesta(false);
                $rootScope.mostrarAlerta(true, 'Advertencia!', 'Ya no hay disponiblilidad de cajas en uno o mas lotes ingresados');
            }



        }
    }


    $scope.generaXML=function(){
        document.getElementById('btnContinuar_').style.display = 'none';
        $scope.btnGeneraXML = 'none';
        //document.getElementById('btnError').style.display = 'none';
        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '';
        $('#cargandoDatosSAP').show();
        $scope.mostrarRespuesta(true);

        //console.log('______DATOS__________');
        //console.log($rootScope.datosPaletiza.manual);
        //console.log($rootScope.datosGranel);

        //for (inx = 0; inx <= $rootScope.countTab; inx++) {
        var siono;
        if (($scope.selPaletizaPCompleto == false)) {
            siono='';
        }else{
            siono='X';
        }
      

        var cadenaXML = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">';
        cadenaXML += '   <soapenv:Header/>';
        cadenaXML += '   <soapenv:Body>';
        cadenaXML += '      <tem:ZXPI_HU_CREA>';
        cadenaXML += '         <tem:datos>';
        cadenaXML += '            <tem:HEADER_HU>';
        cadenaXML += '               <tem:PACK_MAT>P200</tem:PACK_MAT>';
        cadenaXML += '               <tem:HU_EXID>' +  angular.uppercase($scope.paletizaCajaNumeroPalet) + '</tem:HU_EXID>';
        cadenaXML += '               <tem:EXT_ID_HU_2></tem:EXT_ID_HU_2>';
        cadenaXML += '               <tem:CONTENT>' + $scope.selPaletizaTipiPallet.value + '</tem:CONTENT>';
        cadenaXML += '               <tem:PACK_MAT_CUSTOMER></tem:PACK_MAT_CUSTOMER>';
        cadenaXML += '               <tem:PACKAGE_CAT></tem:PACKAGE_CAT>';
        cadenaXML += '               <tem:KZGVH>' + siono + '</tem:KZGVH>';
        cadenaXML += '               <tem:HU_GRP1></tem:HU_GRP1>';
        cadenaXML += '               <tem:HU_GRP2></tem:HU_GRP2>';
        cadenaXML += '               <tem:HU_GRP3></tem:HU_GRP3>';
        cadenaXML += '               <tem:HU_GRP4></tem:HU_GRP4>';
        cadenaXML += '               <tem:HU_GRP5>' + $scope.selPaletizaOtrasC.value + '</tem:HU_GRP5>';
        cadenaXML += '               <tem:LGORT_DS>' + $scope.selPaletizaAlmacenIr + '</tem:LGORT_DS>';
        cadenaXML += '            </tem:HEADER_HU>';
        cadenaXML += '            <tem:HU_EXISTE></tem:HU_EXISTE>';
        cadenaXML += '            <tem:XPI_ITEM_HU>';
        //               <!--Zero or more repetitions:-->
        angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
            if (value.ESTADO_REC == $scope.pop.filtro) {
                cadenaXML += '               <tem:ZXPI_HU_CREA_XPI_ITEM_HU>';
                cadenaXML += '                  <tem:HU_ITEM_TYPE>1</tem:HU_ITEM_TYPE>';
                cadenaXML += '                  <tem:PACK_QTY>' + value.inLotePaletizar + '</tem:PACK_QTY>';
                cadenaXML += '                  <tem:BASE_UNIT_QTY>CS</tem:BASE_UNIT_QTY>';
                cadenaXML += '                  <tem:MATERIAL>' + value.MATNR + '</tem:MATERIAL>';
                cadenaXML += '                  <tem:BATCH>' + value.CHARG + '</tem:BATCH>';
                cadenaXML += '                  <tem:PLANT>' + $rootScope.datoUsuario.acopio + '</tem:PLANT>';
                cadenaXML += '                  <tem:STGE_LOC>' + value.LGORT + '</tem:STGE_LOC>';
                cadenaXML += '                  <tem:STOCK_CAT>S</tem:STOCK_CAT>';
                cadenaXML += '               </tem:ZXPI_HU_CREA_XPI_ITEM_HU>';
                //$rootScope.datosPaletiza.manual[value.idx].CSPEM = Number($rootScope.datosPaletiza.manual[value.idx].CSPEM) - Number(value.inLotePaletizar);
                //$rootScope.datosPaletiza.manual[value.idx].inLotePaletizar = 0;
            }
        });


        cadenaXML += '            </tem:XPI_ITEM_HU>';
        cadenaXML += '         </tem:datos>';
        cadenaXML += '      </tem:ZXPI_HU_CREA>';
        cadenaXML += '   </soapenv:Body>';
        cadenaXML += '</soapenv:Envelope>';
        console.log(cadenaXML)

        /// VALIDAR ENVIO POR USUARIO DEMO OFLINE
        if ($rootScope.datoUsuario.idUsuario != "demo") {
            var xmlhttp = new XMLHttpRequest();
            var mensajeRespuesta1;
            var mensajeRespuesta2;
            xmlhttp.open('POST', 'http://' + IPSERVER + '/'+RUTASERVER+'/rfcNET.asmx', true);
            var sr = cadenaXML;
            xmlhttp.onreadystatechange = function () {
  
                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        document.getElementById('btnContinuar_').style.display = 'block';
                        document.getElementById('loadingCajaEmabalda').style.display = 'none';
                        $('#cargandoDatosSAP').hide('fade');
                        
                        var print = xmlhttp.responseText.split("&lt;").join("<").split("&gt;").join(">").split("&quot;").join('"').split('"').join("'").split("<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>").join("");
                        //$("#response").text(print)

                        var xmlData = $.parseXML(print);

                        try {
                            var thirdPartyNode = $(xmlData).find("HUKEY")[0]; //HUKEY
                            mensajeRespuesta1 = (serializeXmlNode(thirdPartyNode).split("\t").join(""));

                        } catch (e) {
                            mensajeRespuesta1 = 'ERROR, FOLIO NO SE PUEDE OBTENER HUKEY';
                        }

                        //console.log(mensajeRespuesta1);

                        try {
                            var thirdPartyNode = $(xmlData).find("MESSAGE")[0]; //MESSAGE
                            mensajeRespuesta2 = (serializeXmlNode(thirdPartyNode).split("\t").join(""));
                        } catch (e) {
                            mensajeRespuesta2 = 'No hay mensajes de error';
                        }

                        if (mensajeRespuesta1 == '<HUKEY xmlns="http://tempuri.org/"/>') {
                            mensajeRespuesta1 = 'ERROR, FOLIO NO SE PUEDE OBTENER HUKEY';
                        } else {
                            mensajeRespuesta1 = 'Se paletizó correctamente el Folio: ' + mensajeRespuesta1;

                            if (mensajeRespuesta2 == 'No hay mensajes de error') {
                                angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                                    if (value.ESTADO_REC == $scope.pop.filtro) {
                                        $rootScope.datosPaletiza.manual[value.idx].CSPEM = Number($rootScope.datosPaletiza.manual[value.idx].CSPEM) - Number(value.inLotePaletizar);
                                        $rootScope.datosPaletiza.manual[value.idx].inLotePaletizar = 0;
                                    }
                                });
                            }


                        }


                        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '<div class="contabilizar-text"> <h1>Material Document:</h1> <p>' + mensajeRespuesta1 + '</p><h1>Mensajes:</h1><p>' + mensajeRespuesta2 + '</p></div>';
                        
                    }
                    if (xmlhttp.status == 500) {
                        document.getElementById('loadingCajaEmabalda').style.display = 'none';
                        $('#cargandoDatosSAP').hide('fade');
                       // document.getElementById('btnError').style.display = 'block';
                        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML= 'El servidor rechazó recepción de datos!'
                    }
                } 
            }
            // Send the POST request
            xmlhttp.setRequestHeader('Content-Type', 'text/xml');
            xmlhttp.send(sr);
        } else {
            document.getElementById('loadingCajaEmabalda').style.display = 'none';
            document.getElementById('btnContinuar_').style.display = 'block';
            $('#cargandoDatosSAP').hide('fade');
            document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = "DATOS DEMOS CORRECTOS";
        }

    }
    $scope.codearPalet = function () {
        cordova.plugins.barcodeScanner.scan(
        function (result) {
            //alert(result.text)         
            document.getElementById('paletizaCajaNumeroPalet').value = result.text;
            $scope.paletizaCajaNumeroPalet = result.text;
            $scope.paletizajeIngreso();
        },
        function (error) {
            $rootScope.mostrarAlerta(true, "Error", "Scanning failed: " + error);
        }
      );
    }

})

.controller('ctrAumentarDigitar', function ($scope, $routeParams, $rootScope, dataFactory) {
    $('#aumentarDigitar').addClass('animated ' + $routeParams.animacion);


    $scope.buscarPallet = function () {
        if (($scope.numeroPallet == "") || ($scope.numeroPallet == null)) {
            $rootScope.mostrarAlerta(true, 'Advertencia!', 'Ingrese número de pallet');
            return 0;
        }
        $rootScope.verLoading_(true, "Obteniendo información del pallet");
        document.getElementById('preloadMsg').innerHTML = "Obteniendo información del pallet";
        if ($rootScope.datoUsuario.idUsuario == "demo") {


        } else {
            dataFactory.getDatos('HU_READ', 'HUKEY=' + angular.uppercase($scope.numeroPallet))
            .success(function (datos) {
                //console.log(datos);
                //console.log(datos.HUHEADER)
                if ((datos.HUHEADER == undefined) || (datos.HUHEADER == null) || (datos.HUHEADER.length==0)) {
                    $rootScope.verLoading_(false, "");
                    $scope.numeroPallet = '';
                    $rootScope.mostrarAlerta(true, 'Error', 'No se encuentra información del pallet ingresado. SAP MESSAGE:' + datos.RETURN[0].MESSAGE);
                    return 0;
                } else {
                    $rootScope.datosPaletiza.existente = [];
                    $rootScope.datosPaletiza.existente = (datos);
                    $rootScope.preloadMsg = "Obteniendo datos...";
                    $rootScope.verLoading_(true, "Obteniendo datos...");
                    $rootScope.preloadMsg = "Obteniendo datos...";
                    $rootScope.datosLoteProcesoPaking = [];
                    if ($rootScope.datoUsuario.idUsuario == "demo") {
                        $rootScope.STOCK_MCHB = [
                            { "MATNR": "FFA0303", "WERKS": "1050", "LGORT": "0001", "CHARG": "123", "MEINS": "CS", "CLABS": 0, "CINSM": 0, "CSPEM": 516.000, "LIFNR": "0000007016", "ESTADO_REC": "" },
                            { "MATNR": "FFA0330", "WERKS": "1050", "LGORT": "0001", "CHARG": "LOTBULK01", "MEINS": "CS", "CLABS": 0, "CINSM": 0, "CSPEM": 597.000, "LIFNR": "0000007016", "ESTADO_REC": "A" },
                            { "MATNR": "FFA0330", "WERKS": "1050", "LGORT": "0001", "CHARG": "LOTBULK02", "MEINS": "CS", "CLABS": 0, "CINSM": 0, "CSPEM": 400.000, "LIFNR": "0000007016", "ESTADO_REC": "O" },
                            { "MATNR": "FFA0100-JP", "WERKS": "1050", "LGORT": "0001", "CHARG": "0000027419", "MEINS": "CS", "CLABS": 0, "CINSM": 0, "CSPEM": 100.000, "LIFNR": "0000007035", "ESTADO_REC": "" },
                            { "MATNR": "FFA0330", "WERKS": "1050", "LGORT": "0001", "CHARG": "0909090909", "MEINS": "CS", "CLABS": 0, "CINSM": 0, "CSPEM": 10.000, "LIFNR": "0000007016", "ESTADO_REC": "O" },
                            { "MATNR": "FFA0330", "WERKS": "1050", "LGORT": "0001", "CHARG": "9889", "MEINS": "CS", "CLABS": 0, "CINSM": 0, "CSPEM": 200.000, "LIFNR": "0000007016", "ESTADO_REC": "A" }
                        ]
                        $rootScope.verLoading_(false, "");
                        $scope.navegacionPagina('StockAlmacen', 'fadeInRight', '');

                    } else {
                        dataFactory.getDatos('STOCK_LOTES_TB', 'FULL=X&WERKS=' + $rootScope.datoUsuario.acopio)
                            .success(function (datos) {
                                $rootScope.STOCK_MCHB = datos.STOCK_MCHB;
                                dataFactory.getDatos('HU_DICCIONARIO', '')
                                .success(function (datos) {
                                    $rootScope.HU_DICCIONARIO = [];
                                    $rootScope.HU_DICCIONARIO = datos;
                                    //console.log($rootScope.HU_DICCIONARIO);
                                    $scope.navegacionPagina('aumentarLotes', 'fadeInRight', '')
                                })
                                .error(function (datos) {
                                    $rootScope.verLoading_(false, "");
                                    $rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_HU_DICCIONARIO');
                                })

                            })
                            .error(function (datos) {
                                $rootScope.verLoading_(false, "");
                                $rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_STOCK_LOTES_TB');
                            })
                    }   
                }
            })
            .error(function (datos) {
                $rootScope.verLoading_(false, "");
                $rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_HU_READ');
            })
        }

    }

    $scope.codearPalet = function () {
        cordova.plugins.barcodeScanner.scan(
        function (result) {
            //alert(result.text)         
            document.getElementById('numeroPallet').value = result.text;
            $scope.numeroPallet = result.text;
            $scope.buscarPallet();
        },
        function (error) {
            $rootScope.mostrarAlerta(true, "Error", "Scanning failed: " + error);
        }
      );
    }

})

.controller('ctrAumentarLotes', function ($scope, $routeParams, $rootScope, dataFactory) {
    $('#AumentaPallet_Pallet').addClass('animated ' + $routeParams.animacion);
    $rootScope.preloadMsg = "Procesando datos...";
    $rootScope.verLoading_(true, "Procesando datos...");
    $rootScope.preloadMsg = "Procesando datos...";
    //document.getElementById('preloadMsg') = "Obteniendo datos...";
    $scope.ctrVerVentanaSelect = 0;
    //$rootScope.datosPaletiza = {};
    $scope.idxP = 0;
    $scope.stockVisible = { selA: 'block', selO: 'none', selNC: 'none' };
    $scope.estadoTabSel = { ok: 'inactivo', obj: '', no: '' };


    $scope.HU_EXID = Number($rootScope.datosPaletiza.existente.HUHEADER[0].HU_EXID);
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].CLOSED_BOX == 'X') {
        $scope.CLOSED_BOX = 'SI';
    } else {
        $scope.CLOSED_BOX = 'NO';
    }
    
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC == '') {
        $scope.STGE_LOC = '----';
    } else {
        $scope.STGE_LOC = $rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC;
    }
    
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].CONTENT == '') {
        $scope.CONTENT = '----';
    } else {
        $scope.CONTENT = $rootScope.datosPaletiza.existente.HUHEADER[0].CONTENT;
    } 

    if ($rootScope.datosPaletiza.existente.HUHEADER[0].HU_GRP5 == '') {
        $scope.HU_GRP5 = '----';
    } else {
        angular.forEach($rootScope.HU_DICCIONARIO.HU_GRP5, function (value, key) {
            if (value.VEGR5 == $rootScope.datosPaletiza.existente.HUHEADER[0].HU_GRP5) {
                $scope.HU_GRP5 = value.BEZEI;
            }
        });
    }





    $scope.agregaPalet = function (dato) {
        var css = '';
        var ESTADO_REC = ' ';
        switch (dato.ESTADO_REC) {
            case 'A':
                css = 'ok';
                ESTADO_REC='A';
                break;
            case 'O':
                css = 'obj';
                ESTADO_REC='O';
                break;
            case '':
                css = 'sn';
                ESTADO_REC='X';
                break;
        }
        $rootScope.datosPaletiza.manual[$scope.idxP] = {
            idx: $scope.idxP,
            MATNR: dato.MATNR,//"FFA0303",
            WERKS: dato.WERKS,//"1050",
            LGORT: dato.LGORT,//"0001",
            CHARG: dato.CHARG,//"123",
            MEINS: dato.MEINS,//"CS",
            CLABS: dato.CLABS,//0,
            CINS: dato.CINS,//0,
            CSPEM: dato.CSPEM,//516,
            LIFNR: dato.LIFNR,//"0000007016",
            ESTADO_REC: ESTADO_REC,//"" A O '',
            css: css
        }
        $scope.idxP++;

    }

    $scope.cargarStockSelect = function () {
        var idxA = 0; $rootScope.datosPaletiza.selA = [];
        var idxO = 0; $rootScope.datosPaletiza.selO = [];
        var idxNC = 0; $rootScope.datosPaletiza.selNC = [];
        $rootScope.datosPaletiza.manual = [];
        angular.forEach($rootScope.STOCK_MCHB, function (value, key) {
            if ('A' == value.ESTADO_REC) {
                $rootScope.datosPaletiza.selA[idxA] = {
                    idx: idxA,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    seleccionado: 'false'
                };
                idxA++;
            }
            if ('O' == value.ESTADO_REC) {
                $rootScope.datosPaletiza.selO[idxO] = {
                    idx: idxO,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    seleccionado: 'false'
                }
                idxO++;
            }
            if ('' == value.ESTADO_REC) {
                $rootScope.datosPaletiza.selNC[idxNC] = {
                    idx: idxNC,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    seleccionado: false
                }
                idxNC++;
            }
        });
        $rootScope.verLoading_(false, "");
    }

    $scope.cargarStockSelect();

    $scope.verVentanaSelect1 = function () {
        $('#btnAlamcenSelect').removeClass('inactivo');
        $('#VentanStock').hide();
        $('#VentanaSelect').removeClass('animated fadeOutLeft');
        $('#VentanaSelect').show();
        $('#VentanaSelect').addClass('animated fadeInLeft');
        $('#btnAlmacenStock').addClass('inactivo');
        $scope.ctrVerVentanaSelect = 0;
    }

    $scope.verVentanaSelect2 = function () {
        $('#btnAlmacenStock').removeClass('inactivo');
        $('#VentanaSelect').hide();
        $('#VentanStock').removeClass('animated fadeOutLeft');
        $('#VentanStock').show();
        $('#VentanStock').addClass('animated fadeInLeft');
        $('#btnAlamcenSelect').addClass('inactivo');
        $scope.ctrVerVentanaSelect = 1;

        //console.log($rootScope.datosPaletiza)

    }

    $scope.verVentanaSelect1();


    $scope.paletizajeIngreso = function () {
        var existe = 0;
        angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
            if (angular.uppercase($scope.inSelLotesManual) == value.CHARG) {
                existe = 1
            }
        });

        if (existe == 0) {
            var busqueda = 0;
            angular.forEach($rootScope.STOCK_MCHB, function (value, key) {
                if (angular.uppercase($scope.inSelLotesManual) == value.CHARG) {
                    $scope.agregaPalet(value);
                    busqueda = 1;
                }
            });
            if (busqueda == 0) {
                $rootScope.mostrarAlerta(true, 'Error', 'Lote:' + angular.uppercase($scope.inSelLotesManual) + ' no encontrado.');
            }
            $scope.inSelLotesManual = '';
        } else {
            $rootScope.mostrarAlerta(true, 'Advertencia', 'Lote:' + angular.uppercase($scope.inSelLotesManual) + ' ta se encuentra agregado.');
        }
    }

    $scope.selPaletizaQuitar = function (idx) {
        var auxidx = 0;
        $scope.datosPaletizaAux = [];
        $scope.datosPaletizaAux = $rootScope.datosPaletiza.manual;
        $scope.datosPaletiza.manual = [];
        angular.forEach($scope.datosPaletizaAux, function (value, key) {
            if (idx != value.idx) {
                var css = '';
                switch (value.ESTADO_REC) {
                    case 'A':
                        css = 'ok';
                        break;
                    case 'O':
                        css = 'obj';
                        break;
                    case '':
                        css = 'sn';
                        break;
                }
                $rootScope.datosPaletiza.manual[auxidx] = {
                    idx: auxidx,
                    MATNR: value.MATNR,
                    WERKS: value.WERKS,
                    LGORT: value.LGORT,
                    CHARG: value.CHARG,
                    MEINS: value.MEINS,
                    CLABS: value.CLABS,
                    CINS: value.CINS,
                    CSPEM: value.CSPEM,
                    LIFNR: value.LIFNR,
                    ESTADO_REC: value.ESTADO_REC,
                    inLotePaletizar: value.inLotePaletizar
                }
                auxidx++;
            }
        });

    }

    $scope.limpiarCargaScaner = function () {
        $rootScope.datosPaletiza.manual = []
        $scope.idxP = 0;
    }

    $scope.verAlmacenOk = function () {
        $scope.stockVisible = { selA: 'block', selO: 'none', selNC: 'none' };
        $scope.estadoTabSel = { ok: 'inactivo', obj: '', no: '' };
    }

    $scope.verAlmacenObj = function () {
        $scope.stockVisible = { selA: 'none', selO: 'block', selNC: 'none' };
        $scope.estadoTabSel = { ok: '', obj: 'inactivo', no: '' };
    }
    $scope.verAlmacenNC = function () {
        $scope.stockVisible = { selA: 'none', selO: 'none', selNC: 'block' };
        $scope.estadoTabSel = { ok: '', obj: '', no: 'inactivo' };
    }

    $scope.filtroPaletiza = "TODOS";
    $scope.filtroPaletiza = "";


    $scope.continuarPelatizaPaso2 = function () {
        if ($scope.ctrVerVentanaSelect == 0) { // lote manuel
            //console.log($rootScope.datosPaletiza.manual)
            if (($rootScope.datosPaletiza.manual.length == 0) || ($rootScope.datosPaletiza.manual == null)) {
                $rootScope.mostrarAlerta(true, 'Error', 'Ingrese a lo menos un lote');
                return 0;
            }
        }
        if ($scope.ctrVerVentanaSelect == 1) { // lote stock filtro
            var idx = 0;
            $rootScope.datosPaletiza.manual = [];
            angular.forEach($rootScope.datosPaletiza.selA, function (value, key) {
                if (value.seleccionado == true) {
                    $rootScope.datosPaletiza.manual[idx] = {
                        idx: idx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: value.ESTADO_REC,
                        seleccionado: true,
                        inLotePaletizar: 0
                    }
                    idx++;
                }
            });
            angular.forEach($rootScope.datosPaletiza.selO, function (value, key) {
                if (value.seleccionado == true) {
                    $rootScope.datosPaletiza.manual[idx] = {
                        idx: idx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: value.ESTADO_REC,
                        seleccionado: true,
                        inLotePaletizar: 0
                    }
                    idx++;
                }
            });
            angular.forEach($rootScope.datosPaletiza.selNC, function (value, key) {
                if (value.seleccionado == true) {
                    $rootScope.datosPaletiza.manual[idx] = {
                        idx: idx,
                        MATNR: value.MATNR,
                        WERKS: value.WERKS,
                        LGORT: value.LGORT,
                        CHARG: value.CHARG,
                        MEINS: value.MEINS,
                        CLABS: value.CLABS,
                        CINS: value.CINS,
                        CSPEM: value.CSPEM,
                        LIFNR: value.LIFNR,
                        ESTADO_REC: 'X',
                        seleccionado: true,
                        inLotePaletizar: 0
                    }
                    idx++;
                }
            });
            if (idx == 0) {
                $rootScope.mostrarAlerta(true, 'Error', 'Ingrese a lo menos un lote');
                return 0;
            }
        }
        $scope.navegacionPagina('aumentarCajas', 'fadeInRight', '');

    }

    $scope.codearPalet = function () {
        cordova.plugins.barcodeScanner.scan(
        function (result) {
            //alert(result.text)         
            document.getElementById('inSelLotesManual').value = result.text;
            $scope.inSelLotesManual = result.text;
            $scope.paletizajeIngreso();
        },
        function (error) {
            $rootScope.mostrarAlerta(true, "Error", "Scanning failed: " + error);
        }
      );
    }

})

.controller('ctrAumentarCajas', function ($scope, $routeParams, $rootScope, dataFactory) {
    $('#AumentaPallet_Digitar').addClass('animated ' + $routeParams.animacion);

    $scope.HU_EXID = Number($rootScope.datosPaletiza.existente.HUHEADER[0].HU_EXID);
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].CLOSED_BOX == 'X') {
        $scope.CLOSED_BOX = 'SI';
    } else {
        $scope.CLOSED_BOX = 'NO';
    }
    
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC == '') {
        $scope.STGE_LOC = '----';
    } else {
        $scope.STGE_LOC = $rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC;
    }
    
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].CONTENT == '') {
        $scope.CONTENT = '----';
    } else {
        $scope.CONTENT = $rootScope.datosPaletiza.existente.HUHEADER[0].CONTENT;
    }

    if ($rootScope.datosPaletiza.existente.HUHEADER[0].HU_GRP5 == '') {
        $scope.HU_GRP5 = '----';
    } else {
        angular.forEach($rootScope.HU_DICCIONARIO.HU_GRP5, function (value, key) {
            if (value.VEGR5 == $rootScope.datosPaletiza.existente.HUHEADER[0].HU_GRP5) {
                $scope.HU_GRP5 = value.BEZEI;
            }
        });
    }



    $scope.mostrarRespuesta = function (estado) {
        if (estado == true) {
            $scope.verPopRespuesta = "block";
            //$scope.verBtnFin = "none";
        } else {
            $scope.verPopRespuesta = "none";
            //$scope.verBtnFin = "block";
        }
    }
    // estableser oculto
    $scope.mostrarRespuesta(false);

    $scope.countVerifica = 0;
    $scope.countRealizado = 0;

    $scope.aceptaPaletizarCajaEmbalada = function () {
        //document.getElementById('btnContinuar_').style.display = 'none';
        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '';
        $('#cargandoDatosSAP').show();
        $scope.mostrarRespuesta(true);
        if ($rootScope.datoUsuario.idUsuario == "demo") {
            // stco OK
        } else {//$scope.pop.filtro
            // verificar stock disponible
            $scope.countVerifica = 0;
            $scope.countRealizado = 0;

            angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                $scope.countVerifica++;
                //console.log($scope.countVerifica)
            });

            angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                    var aux = $scope.verificaSaldo(value.CHARG, value.LGORT, value.idx);
            });

        }
    }

    $scope.verificaSaldo = function (CHARG, LGORT, idx) {
        //console.log(CHARG + " -*- " + LGORT)
        dataFactory.getDatos('STOCK_LOTES_TB', 'CHARG=' + CHARG + '&WERKS=' + $rootScope.datoUsuario.acopio)
            .success(function (datos) {
                //console.log(datos.STOCK_MCHB.length)
                for (i = 0; i < datos.STOCK_MCHB.length; i++) {
                    if (datos.STOCK_MCHB[i].LGORT == LGORT) {
                        $rootScope.datosPaletiza.manual[idx].CSPEM = datos.STOCK_MCHB[i].CSPEM;
                        //console.log(datos.STOCK_MCHB[i].CSPEM)
                        $scope.estadoObteniendo();
                        return 0;
                    }
                }
            })
            .error(function (datos) {
                $scope.mostrarRespuesta(false);
                $rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_STOCK_LOTES_TB');
                return 0;
            })
    }

    $scope.estadoObteniendo = function () {
        $scope.countRealizado++;
        //console.log($scope.countRealizado +'>='+ $scope.countVerifica)
        if ($scope.countRealizado >= $scope.countVerifica) {
            // se actualizaron todos los saldos de stock

            //console.log($rootScope.datosPaletiza.manual);

            var estado = 0;

            angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                    if (value.inLotePaletizar <= value.CSPEM) {
                        //console.log("OK Si existen saldos en todos los lotes se procede envio XML");
                        
                    } else {
                        //console.log("ya no hay disponible");
                        estado = -1;
                    }

            });

            if (estado == 0) {
                $scope.generaXML();
            } else {
                $scope.mostrarRespuesta(false);
                $rootScope.mostrarAlerta(true, 'Advertencia!', 'Ya no hay disponiblilidad de cajas en uno o mas lotes ingresados');
            }


        }
    }

    $scope.generaXML = function () {
        document.getElementById('btnContinuar_').style.display = 'none';
        $scope.btnGeneraXML = 'none';
        //document.getElementById('btnError').style.display = 'none';
        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '';
        $('#cargandoDatosSAP').show();
        $scope.mostrarRespuesta(true);

        //console.log('______DATOS__________');
        //console.log($rootScope.datosPaletiza.manual);
        //console.log($rootScope.datosGranel);

        //for (inx = 0; inx <= $rootScope.countTab; inx++) {
        var siono;
        if (($scope.selPaletizaPCompleto == false)) {
            siono = '';
        } else {
            siono = 'X';
        }


        var cadenaXML = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">';
        cadenaXML += '   <soapenv:Header/>';
        cadenaXML += '   <soapenv:Body>';
        cadenaXML += '      <tem:ZXPI_HU_PACK>';
        cadenaXML += '         <tem:datos>';
        cadenaXML += '            <tem:HUKEY>' + $rootScope.datosPaletiza.existente.HUHEADER[0].HU_EXID + '</tem:HUKEY>';
        cadenaXML += '            <tem:IT_ITEMPROPOSAL>';
        //               <!--Zero or more repetitions:-->
        angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                cadenaXML += '               <tem:ZXPI_HU_PACK_IT_ITEMPROPOSAL>';
                cadenaXML += '                  <tem:HU_ITEM_TYPE>1</tem:HU_ITEM_TYPE>';
                cadenaXML += '                  <tem:LOWER_LEVEL_EXID></tem:LOWER_LEVEL_EXID>';
                cadenaXML += '                  <tem:PACK_QTY>' + $rootScope.datosPaletiza.manual[value.idx].inLotePaletizar + '</tem:PACK_QTY>';
                cadenaXML += '                  <tem:BASE_UNIT_QTY_ISO></tem:BASE_UNIT_QTY_ISO>';
                cadenaXML += '                  <tem:BASE_UNIT_QTY>' + value.MEINS + '</tem:BASE_UNIT_QTY>';
                cadenaXML += '                  <tem:NUMBER_PACK_MAT>0</tem:NUMBER_PACK_MAT>';
                cadenaXML += '                  <tem:FLAG_SUPLMT_ITEM></tem:FLAG_SUPLMT_ITEM>';
                cadenaXML += '                  <tem:MATERIAL>' + value.MATNR + '</tem:MATERIAL>';
                cadenaXML += '                  <tem:BATCH>' + value.CHARG + '</tem:BATCH>';
                cadenaXML += '                  <tem:PLANT>' + value.WERKS + '</tem:PLANT>';
                cadenaXML += '                  <tem:STGE_LOC>' + value.LGORT + '</tem:STGE_LOC>'; 
                cadenaXML += '                  <tem:STOCK_CAT>S</tem:STOCK_CAT>';
                cadenaXML += '                  <tem:SPEC_STOCK></tem:SPEC_STOCK>';
                cadenaXML += '                  <tem:SP_STCK_NO></tem:SP_STCK_NO>';
                cadenaXML += '                  <tem:MATERIAL_PARTNER></tem:MATERIAL_PARTNER>';
                cadenaXML += '                  <tem:EXPIRYDATE></tem:EXPIRYDATE>';
                cadenaXML += '                  <tem:GR_DATE></tem:GR_DATE>';
                cadenaXML += '                  <tem:MATERIAL_EXTERNAL></tem:MATERIAL_EXTERNAL>';
                cadenaXML += '                  <tem:MATERIAL_GUID></tem:MATERIAL_GUID>';
                cadenaXML += '                  <tem:MATERIAL_VERSION></tem:MATERIAL_VERSION>';
                cadenaXML += '               </tem:ZXPI_HU_PACK_IT_ITEMPROPOSAL>';
                //cadenaXML += '                  <tem:PACK_QTY>' + value.inLotePaletizar + '</tem:PACK_QTY>';
        });


        cadenaXML += '            </tem:IT_ITEMPROPOSAL>';
        cadenaXML += '         </tem:datos>';
        cadenaXML += '      </tem:ZXPI_HU_PACK>';
        cadenaXML += '   </soapenv:Body>';
        cadenaXML += '</soapenv:Envelope>';
        //console.log(cadenaXML)

        /// VALIDAR ENVIO POR USUARIO DEMO OFLINE
        if ($rootScope.datoUsuario.idUsuario != "demo") {
            var xmlhttp = new XMLHttpRequest();
            var mensajeRespuesta1;
            var mensajeRespuesta2;
            xmlhttp.open('POST', 'http://' + IPSERVER + '/'+RUTASERVER+'/rfcNET.asmx', true);
            var sr = cadenaXML;
            xmlhttp.onreadystatechange = function () {

                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        document.getElementById('btnContinuar_').style.display = 'block';
                        document.getElementById('loadingCajaEmabalda').style.display = 'none';
                        $('#cargandoDatosSAP').hide('fade');

                        var print = xmlhttp.responseText.split("&lt;").join("<").split("&gt;").join(">").split("&quot;").join('"').split('"').join("'").split("<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>").join("");
                        //$("#response").text(print)

                        var xmlData = $.parseXML(print);

                        try {
                            var thirdPartyNode = $(xmlData).find("MESSAGE_V1")[0]; //MESSAGE_V1
                            mensajeRespuesta1 = (serializeXmlNode(thirdPartyNode).split("\t").join(""));

                        } catch (e) {
                            mensajeRespuesta1 = 'ERROR, FOLIO NO SE PUEDE OBTENER Material document';
                        }

                        try {
                            var thirdPartyNode = $(xmlData).find("MESSAGE")[0]; //MESSAGE
                            mensajeRespuesta2 = (serializeXmlNode(thirdPartyNode).split("\t").join(""));
                        } catch (e) {
                            mensajeRespuesta2 = 'No hay mensajes de error';
                        }

                        if (mensajeRespuesta1 == '<HUKEY xmlns="http://tempuri.org/"/>') {
                            mensajeRespuesta1 = 'ERROR, FOLIO NO SE PUEDE OBTENER 3089900001004';
                        } else {
                            mensajeRespuesta1 = '' + mensajeRespuesta1;

                            //console.log(mensajeRespuesta2);
                            

                            if ((mensajeRespuesta2 == 'No hay mensajes de error')||(mensajeRespuesta2 == '<MESSAGE xmlns="http://tempuri.org/"/>')) {
                                mensajeRespuesta2 = 'No hay mensajes de error';
                                angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
                                    $rootScope.datosPaletiza.manual[value.idx].CSPEM = Number($rootScope.datosPaletiza.manual[value.idx].CSPEM) - Number(value.inLotePaletizar);
                                    $rootScope.datosPaletiza.manual[value.idx].inLotePaletizar = 0;
                                });
                            }

                        }

                        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '<div class="contabilizar-text"> <h1>Material Document:</h1> <p>' + mensajeRespuesta1 + '</p><h1>Mensajes:</h1><p>' + mensajeRespuesta2 + '</p></div>';

                    }
                    if (xmlhttp.status == 500) {
                        document.getElementById('loadingCajaEmabalda').style.display = 'none';
                        $('#cargandoDatosSAP').hide('fade');
                        // document.getElementById('btnError').style.display = 'block';
                        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = 'El servidor rechazó recepción de datos!'
                    }
                }
            }
            // Send the POST request
            xmlhttp.setRequestHeader('Content-Type', 'text/xml');
            xmlhttp.send(sr);
        } else {
            document.getElementById('loadingCajaEmabalda').style.display = 'none';
            document.getElementById('btnContinuar_').style.display = 'block';
            $('#cargandoDatosSAP').hide('fade');
            document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = "DATOS DEMOS CORRECTOS";
        }

    }


})

.controller('ctrQuitarPallet_cod', function ($scope, $routeParams, $rootScope, dataFactory) {
    $('#QuitarPallet_cod').addClass('animated ' + $routeParams.animacion);


    $scope.buscarPallet = function () {
        if (($scope.numeroPallet == "") || ($scope.numeroPallet == null)) {
            $rootScope.mostrarAlerta(true, 'Advertencia!', 'Ingrese número de pallet');
            return 0;
        }
        $rootScope.verLoading_(true, "Obteniendo información del pallet");
        document.getElementById('preloadMsg').innerHTML = "Obteniendo información del pallet";
        if ($rootScope.datoUsuario.idUsuario == "demo") {


        } else {
            dataFactory.getDatos('HU_READ', 'HUKEY=' + angular.uppercase($scope.numeroPallet))
            .success(function (datos) {
                //console.log(datos);
                //console.log(datos.HUHEADER)
                $rootScope.datosPaletiza.existente = [];
                $rootScope.datosPaletiza.existente = (datos);

                if ((datos.HUHEADER == undefined) || (datos.HUHEADER == null) || (datos.HUHEADER.length == 0)) {
                    $rootScope.verLoading_(false, "");
                    $rootScope.mostrarAlerta(true, 'Error', 'No se encuentra información del pallet ingresado. SAP MESSAGE:' + datos.RETURN[0].MESSAGE);
                    $scope.numeroPallet = '';
                    return 0;
                }
                dataFactory.getDatos('HU_DICCIONARIO', '')
                    .success(function (datos) {
                        $rootScope.HU_DICCIONARIO = [];
                        $rootScope.HU_DICCIONARIO = datos;
                        //console.log($rootScope.HU_DICCIONARIO);
                        $scope.navegacionPagina('QuitarPallet_Pallet', 'fadeInRight', '');
                    })
                    .error(function (datos) {
                        $rootScope.verLoading_(false, "");
                        $rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_HU_DICCIONARIO');
                    })
                
            })
            .error(function (datos) {
                $rootScope.verLoading_(false, "");
                $rootScope.mostrarAlerta(true, 'Error', 'No se puede conectar al servicio:JSON_ZXPI_HU_READ');
            })
        }

    }

    $scope.codearPalet = function () {
        cordova.plugins.barcodeScanner.scan(
        function (result) {
            //alert(result.text)         
            document.getElementById('numeroPallet').value = result.text;
            $scope.numeroPallet = result.text;
            $scope.buscarPallet();
        },
        function (error) {
            $rootScope.mostrarAlerta(true, "Error", "Scanning failed: " + error);
        }
      );
    }

})

.controller('ctrQuitarPallet_Pallet', function ($scope, $routeParams, $rootScope, dataFactory) {
    //console.log($rootScope.datosPaletiza.existente)
    $('#QuitarPallet_Pallet').addClass('animated ' + $routeParams.animacion);
    $scope.HU_EXID = Number($rootScope.datosPaletiza.existente.HUHEADER[0].HU_EXID);
    if ($rootScope.datosPaletiza.existente.HUHEADER[0].CLOSED_BOX == 'X') {
        $scope.CLOSED_BOX = 'SI';
    } else {
        $scope.CLOSED_BOX = 'NO';
    }

    if ($rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC == '') {
        $scope.STGE_LOC = '----';
    } else {
        $scope.STGE_LOC = $rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC;
    }

    if ($rootScope.datosPaletiza.existente.HUHEADER[0].CONTENT == '') {
        $scope.CONTENT = '----';
    } else {
        $scope.CONTENT = $rootScope.datosPaletiza.existente.HUHEADER[0].CONTENT;
    }

    if ($rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC == '') {
        $scope.STGE_LOC = '----';
    } else {
        $scope.STGE_LOC = $rootScope.datosPaletiza.existente.HUHEADER[0].STGE_LOC;
    }

    if ($rootScope.datosPaletiza.existente.HUHEADER[0].HU_GRP5 == '') {
        $scope.HU_GRP5 = '----';
    } else {
        angular.forEach($rootScope.HU_DICCIONARIO.HU_GRP5, function (value, key) {
            if (value.VEGR5 == $rootScope.datosPaletiza.existente.HUHEADER[0].HU_GRP5) {
                $scope.HU_GRP5 = value.BEZEI;
            }
        });
    }
    $scope.limpiaDatos = function () {

            var idx = 0;
            $rootScope.datosPaletiza.manual = [];
            angular.forEach($rootScope.datosPaletiza.existente.HUITEM, function (value, key) {
                $rootScope.datosPaletiza.manual[idx] = {
                    idx: idx,
                    MATNR: value.MATERIAL,
                    WERKS: value.PLANT,
                    LGORT: value.STGE_LOC,
                    CHARG: value.BATCH,
                    MEINS: value.BASE_UNIT_QTY,
                    CLABS: 0,// value.CLABS,
                    CINS: '',//value.CINS,
                    CSPEM: value.PACK_QTY,
                    LIFNR: '',//value.LIFNR,
                    ESTADO_REC: value.STGE_LOC,
                    seleccionado: true,
                    inLotePaletizar: 0
                }
                    idx++;
            });
            $rootScope.verLoading_(false, "");
    }

    $scope.limpiaDatos();


    $scope.mostrarRespuesta = function (estado) {
        if (estado == true) {
            $scope.verPopRespuesta = "block";
            //$scope.verBtnFin = "none";
        } else {
            $scope.verPopRespuesta = "none";
            //$scope.verBtnFin = "block";
        }
    }
    // estableser oculto
    $scope.mostrarRespuesta(false);

    $scope.countVerifica = 0;
    $scope.countRealizado = 0;

    $scope.aceptaPaletizarCajaEmbalada = function () {
        //document.getElementById('btnContinuar_').style.display = 'none';
        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '';
        $('#cargandoDatosSAP').show();
        $scope.mostrarRespuesta(true);
        // para enviar valor calculado,  lo que venia mas lo del usuario ocupar la funcion,!!
        //      angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
        //         $rootScope.datosPaletiza.manual[value.idx].CSPEM = Number(value.CSPEM) + Number(value.inLotePaletizar);
        //         $rootScope.datosPaletiza.manual[value.idx].inLotePaletizar = 0;
        //         });
           $scope.generaXML();
    }

    $scope.generaXML = function () {
        document.getElementById('btnContinuar_').style.display = 'none';
        $scope.btnGeneraXML = 'none';
        //document.getElementById('btnError').style.display = 'none';
        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '';
        $('#cargandoDatosSAP').show();
        $scope.mostrarRespuesta(true);

        //console.log('______DATOS__________');
        //console.log($rootScope.datosPaletiza.manual);
        //console.log($rootScope.datosGranel);

        //for (inx = 0; inx <= $rootScope.countTab; inx++) {
        var siono;
        if (($scope.selPaletizaPCompleto == false)) {
            siono = '';
        } else {
            siono = 'X';
        }


        var cadenaXML = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">';
        cadenaXML += '   <soapenv:Header/>';
        cadenaXML += '   <soapenv:Body>';
        cadenaXML += '      <tem:ZXPI_HU_UNPACK>';
        cadenaXML += '         <tem:datos>';
        cadenaXML += '            <tem:HUKEY>' + $rootScope.datosPaletiza.existente.HUHEADER[0].HU_EXID + '</tem:HUKEY>';
        cadenaXML += '            <tem:IT_ITEMUNPACK>';
        //               <!--Zero or more repetitions:-->
        angular.forEach($rootScope.datosPaletiza.manual, function (value, key) {
            cadenaXML += '               <tem:ZXPI_HU_UNPACK_IT_ITEMUNPACK>';
            cadenaXML += '                  <tem:HU_ITEM_TYPE>1</tem:HU_ITEM_TYPE>';
            cadenaXML += '                  <tem:LOWER_LEVEL_EXID></tem:LOWER_LEVEL_EXID>';
            cadenaXML += '                  <tem:PACK_QTY>' + $rootScope.datosPaletiza.manual[value.idx].inLotePaletizar + '</tem:PACK_QTY>';
            cadenaXML += '                  <tem:BASE_UNIT_QTY_ISO></tem:BASE_UNIT_QTY_ISO>';
            cadenaXML += '                  <tem:BASE_UNIT_QTY>' + value.MEINS + '</tem:BASE_UNIT_QTY>';
            cadenaXML += '                  <tem:NUMBER_PACK_MAT>0</tem:NUMBER_PACK_MAT>';
            cadenaXML += '                  <tem:FLAG_SUPLMT_ITEM></tem:FLAG_SUPLMT_ITEM>';
            cadenaXML += '                  <tem:MATERIAL>' + value.MATNR + '</tem:MATERIAL>';
            cadenaXML += '                  <tem:BATCH>' + value.CHARG + '</tem:BATCH>';
            cadenaXML += '                  <tem:PLANT>' + value.WERKS + '</tem:PLANT>';
            cadenaXML += '                  <tem:STGE_LOC>' + value.LGORT + '</tem:STGE_LOC>';
            cadenaXML += '                  <tem:STOCK_CAT>S</tem:STOCK_CAT>';
            cadenaXML += '                  <tem:SPEC_STOCK></tem:SPEC_STOCK>';
            cadenaXML += '                  <tem:SP_STCK_NO></tem:SP_STCK_NO>';
            cadenaXML += '                  <tem:MATERIAL_PARTNER></tem:MATERIAL_PARTNER>';
            cadenaXML += '                  <tem:EXPIRYDATE></tem:EXPIRYDATE>';
            cadenaXML += '                  <tem:GR_DATE></tem:GR_DATE>';
            cadenaXML += '                  <tem:MATERIAL_EXTERNAL></tem:MATERIAL_EXTERNAL>';
            cadenaXML += '                  <tem:MATERIAL_GUID></tem:MATERIAL_GUID>';
            cadenaXML += '                  <tem:MATERIAL_VERSION></tem:MATERIAL_VERSION>';
            cadenaXML += '               </tem:ZXPI_HU_UNPACK_IT_ITEMUNPACK>';
        });


        cadenaXML += '            </tem:IT_ITEMUNPACK>';
        cadenaXML += '         </tem:datos>';
        cadenaXML += '      </tem:ZXPI_HU_UNPACK>';
        cadenaXML += '   </soapenv:Body>';
        cadenaXML += '</soapenv:Envelope>';
        //console.log(cadenaXML)

        /// VALIDAR ENVIO POR USUARIO DEMO OFLINE
        if ($rootScope.datoUsuario.idUsuario != "demo") {
            var xmlhttp = new XMLHttpRequest();
            var mensajeRespuesta1;
            var mensajeRespuesta2;
            xmlhttp.open('POST', 'http://' + IPSERVER + '/'+RUTASERVER+'/rfcNET.asmx', true);
            var sr = cadenaXML;
            xmlhttp.onreadystatechange = function () {

                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        document.getElementById('btnContinuar_').style.display = 'block';
                        document.getElementById('loadingCajaEmabalda').style.display = 'none';
                        $('#cargandoDatosSAP').hide('fade');

                        var print = xmlhttp.responseText.split("&lt;").join("<").split("&gt;").join(">").split("&quot;").join('"').split('"').join("'").split("<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>").join("");
                        //$("#response").text(print)

                        var xmlData = $.parseXML(print);

                        try {
                            var thirdPartyNode = $(xmlData).find("MESSAGE_V1")[0]; //MESSAGE_V1
                            mensajeRespuesta1 = (serializeXmlNode(thirdPartyNode).split("\t").join(""));

                        } catch (e) {
                            mensajeRespuesta1 = 'ERROR, FOLIO NO SE PUEDE OBTENER Material document';
                        }

                        try {
                            var thirdPartyNode = $(xmlData).find("MESSAGE")[0]; //MESSAGE
                            mensajeRespuesta2 = (serializeXmlNode(thirdPartyNode).split("\t").join(""));
                        } catch (e) {
                            mensajeRespuesta2 = 'No hay mensajes de error';
                        }

                        //console.log()

                        if (mensajeRespuesta1 == '<HUKEY xmlns="http://tempuri.org/"/>') {
                            mensajeRespuesta1 = 'ERROR, FOLIO NO SE PUEDE OBTENER Material document';
                        } else {
                            mensajeRespuesta1 = '' + mensajeRespuesta1;

                            if ((mensajeRespuesta2 == 'No hay mensajes de error') || (mensajeRespuesta2 == '<MESSAGE xmlns="http://tempuri.org/"/>')) {
                                mensajeRespuesta2 = 'No hay mensajes de error';
                            }

                        }


                        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = '<div class="contabilizar-text"> <h1>Material Document:</h1> <p>' + mensajeRespuesta1 + '</p><h1>Mensajes:</h1><p>' + mensajeRespuesta2 + '</p></div>';

                    }
                    if (xmlhttp.status == 500) {
                        document.getElementById('loadingCajaEmabalda').style.display = 'none';
                        $('#cargandoDatosSAP').hide('fade');
                        // document.getElementById('btnError').style.display = 'block';
                        document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = 'El servidor rechazó recepción de datos!'
                    }
                }
            }
            // Send the POST request
            xmlhttp.setRequestHeader('Content-Type', 'text/xml');
            xmlhttp.send(sr);
        } else {
            document.getElementById('loadingCajaEmabalda').style.display = 'none';
            document.getElementById('btnContinuar_').style.display = 'block';
            $('#cargandoDatosSAP').hide('fade');
            document.getElementById('popRespuestaEnvioCajaEmbalada').innerHTML = "DATOS DEMOS CORRECTOS";
        }

    }


})