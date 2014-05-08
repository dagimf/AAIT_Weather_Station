angular
	.module('weatherApp')
	.controller('aboutCtrl', ['$scope', function($scope){
		$scope.title ="About";
		$scope.names = ['Tsegaye AG', 'Dagim F', 'Mathias AA'];
	}]);