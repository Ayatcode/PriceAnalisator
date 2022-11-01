//#region Task1

// let arr = [1, 2, 3, 4, 5];
// let sum = 0;
// for (let index = 0; index < arr.length; index++) {
//   sum += arr[index];
// }

// let result = sum / arr.length;

// console.log(result);

//#endregion

//#region Task2

// let arr = [1, 2, 3, -4, 5, -6];

// let plus = 0;
// let minus = 0;

// for (let index = 0; index < arr.length; index++) {
//   if (arr[index] > 0) {
//     plus++;
//   } else if (arr[index] < 0) {
//     minus++;
//   }
// }

// console.log("menfi ededlerin sayi" + minus);
// console.log("mesbet ededlerin sayi" + plus);

//#endregion

//#region task3

let arr = [1, 2, 3, 4, 5, 6];

let max = 0;

for (let index = 0; index < arr.length; index++) {
  if (arr[index] > max) {
    max = arr[index];
  }
}

console.log(max);

//#endregion
