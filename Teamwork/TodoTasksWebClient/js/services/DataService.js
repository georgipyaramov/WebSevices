﻿App.service("dataService", [
    "$http",
    function ($http) {
        var url = "http://localhost:56841";

        var dataService = {
            serverUrl: url,
            getAllCategories: function () {
                var promise = $http.get(url + "/api/Categories/All").then(function (result) {
                    return result.data;
                });

                return promise;
            },
            createCategory: function (categoryName) {
                var promise = $http.post(url + "/api/Categories/Create", { Name: categoryName }).then(function (result) {
                    return result.data;
                });

                return promise;
            },
            deleteCategory: function (categoryId) {
                var promise = $http.delete(url + "/api/Categories/Delete/" + categoryId).then(function () {
                    console.log('deleted category: ' + categoryId);
                });

                return promise;
            },
            getTasksByCategory: function (categoryId) {
                var promise = $http.get(url + "/api/Tasks/FilterByCategory?categoryId=" + categoryId).then(function (result) {
                    return result.data;
                });

                return promise;
            },
            getAllTasks: function () {
                var promise = $http.get(url + "/api/Tasks/All").then(function (result) {
                    return result.data;
                });

                return promise;
            },
            createTask: function (taskContent, deadline, categoryId) {
                var promise = $http.post(url + "/api/Tasks/Create", {
                    Content: taskContent,
                    Deadline: deadline,
                    Status: 1,
                    CategoryId: categoryId
                }).then(function (result) {
                    return result.data;
                });

                return promise;
            },
            deleteTask: function (taskId) {
                var promise = $http.delete(url + "/api/Tasks/Delete/" + taskId).then(function () {
                    console.log('deleted task: ' + taskId);
                }, function (err) {
                    console.log(err);
                });

                return promise;
            },
            changeTask: function (task) {
                var promise = $http.put(url + "/api/Tasks/Update/" + task.Id, {
                    Id: task.Id,
                    Content: task.Content,
                    Status: task.Status,
                    CategoryId: task.CategoryId
                }).then(function () {
                    console.log('changed task: ' + task.Id + ' - status : ' + task.Status);
                }, function (err) {
                    console.log(err);
                });

                return promise;
            }
        };

        return dataService;
    }]);
//# sourceMappingURL=DataService.js.map
