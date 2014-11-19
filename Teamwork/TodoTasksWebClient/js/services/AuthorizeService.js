"use strict";
App.factory("authService", [
    "$http", "$q", "localStorageService", "dataService",
    function ($http, $q, localStorageService, dataService) {
        var serviceBase = dataService.serverUrl + "/";

        var _authentication = {
            token: "",
            isAuth: false,
            userName: ""
        };

        var _saveRegistration = function (registration) {
            _logOut();

            return $http.post(serviceBase + "api/account/register", registration).then(function (response) {
                return response;
            });
        };

        var _login = function (credentials) {
            var data = "grant_type=password&username=" + credentials.userName + "&password=" + credentials.password;

            var deferred = $q.defer();

            $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                _authentication.token = response.access_token;
                _authentication.isAuth = true;
                _authentication.userName = credentials.userName;

                localStorageService.set('authorizationData', _authentication);

                deferred.resolve(response);
            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        };

        var _logOut = function () {
            localStorageService.remove('authorizationData');

            _authentication.token = "";
            _authentication.isAuth = false;
            _authentication.userName = "";
        };

        var _fillAuthData = function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.token = authData.token;
                _authentication.isAuth = authData.isAuth;
                _authentication.userName = authData.userName;
            }
        };

        var authServiceFactory = {
            saveRegistration: _saveRegistration,
            login: _login,
            logOut: _logOut,
            fillAuthData: _fillAuthData,
            authentication: _authentication
        };

        return authServiceFactory;
    }]);
//# sourceMappingURL=AuthorizeService.js.map
