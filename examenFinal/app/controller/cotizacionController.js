angular.module('angular.cotizacionController2', [])
.controller('cotizacionController', ['$scope','$http',function ($scope,$http) {
    
    $scope.MostrarControles = false;
    $scope.listaTipoCarga = {};
    $scope.listaCobros = {};
    $scope.unidadPeso = { opciones: [{ 'id': 01, 'unidad': 'Kg' }, { 'id': 02, 'unidad': 'Lb' }] };
    $scope.Cotizacion = 0.00;
    $scope.detalleCotizacion = {
        idTipoCobro:{},
        nombre: {},
        total:{}
    };
    $scope.model = {
        idTipoCobro: {},
        nombre: {},
        total: {}
    };
   
    $http.get('/TipoCargas/getTipoCarga').success(function (data) {
        $scope.listaTipoCarga = data;
 
    });
    $http.get('/TipoCobroes/getCobros').success(function (data) {
        $scope.listaCobros = data;
    });
   
    $scope.sumar = function (numero) {
       
        $scope.Cotizacion = $scope.Cotizacion + numero.idTipoCobro;
        $scope.detalleCotizacion.idTipoCobro = numero.idTipoCobro;
        $scope.detalleCotizacion.nombre = numero.descripcion;
        $scope.detalleCotizacion.total = numero.idTipoCobro;
        $scope.model.push(detalleCotizacion);
 
    }



}]);