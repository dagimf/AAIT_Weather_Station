angular
	.module('weatherApp')
	.controller('homeCtrl', ['$scope', function($scope){
		$scope.title ="Home";
		$scope.items = ['Weather','Map', 'About'];
		
	}]);