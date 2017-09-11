/// 
/// Directives
/// -------------------------------------------------------------------------------------------------------------------
/// <reference path="_references.ts" />
angular.module('app.directives', [])
    .directive('appVersion', ['version', function (version) {
        return function (scope, elm, attrs) {
            elm.text(version);
        };
    }]);
//# sourceMappingURL=directives.js.map