const grid = document.querySelector(".mvc-grid");

// Triggered when grid's row is clicked. It's recommended to use event delegation in ajax scenarios.
document.addEventListener("rowclick", e => {
    viewPatient(e);
});