let btn = document.getElementById("btn");
let input_name = document.getElementById("name");
let input_surname = document.getElementById("surname");
let input_age = document.getElementById("age");
let table = document.getElementById("table");

btn.addEventListener("click", function () {
  if (/\d/.test(input_age.value)) {
    table.innerHTML += `<tr>
        
    <td>${input_name.value}</td>
    <td>${input_surname.value}</td>
    <td>${input_age.value}</td>
  </tr>`;
  }
});

input_name.onkeyup = function () {
  if (input_name.value == 0) {
    input_name.nextElementSibling.style.display = "block";
  } else {
    input_name.nextElementSibling.style.display = "none";
  }
};

input_surname.onkeyup = function () {
  if (input_surname.value == 0) {
    input_surname.nextElementSibling.style.display = "block";
  } else {
    input_surname.nextElementSibling.style.display = "none";
  }
};

input_age.onkeyup = function () {
  if (input_age.value == 0) {
    input_age.nextElementSibling.style.display = "block";
  } else {
    input_age.nextElementSibling.style.display = "none";
  }
};
