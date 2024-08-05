// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const danger = () => window.confirm("Are you sure you want to delete this record?");
const deleteItem = path => {
    document.querySelector(".btn-proceed").href = path;
    return false;
};