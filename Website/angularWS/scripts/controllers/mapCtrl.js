angular
	.module('weatherApp')
	.controller('mapCtrl', ['$scope', function($scope){
		$scope.title ="Map";
		$scope.items = ['Home','Weather', 'About'];
	}]);