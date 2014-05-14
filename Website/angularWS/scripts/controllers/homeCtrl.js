angular
	.module('weatherApp')
	.controller('homeCtrl', ['$scope', function($scope){
		$scope.title ="Home Changed";
		$scope.items = ['Weather','Map', 'About'];
		
	}]);