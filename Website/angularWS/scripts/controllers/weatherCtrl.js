angular
	.module('weatherApp')
	.controller('weatherCtrl', ['$scope', function($scope){
		$scope.title ="Weather";
		$scope.items = ['Home', 'Map', 'About'];
	}]);