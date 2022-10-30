//#region  Task1
// let num = 256;
// let i = 2;

// while (num >= i) {
//   i = i * 2;
//   if (num== i) {
//     console.log("2 ededin quvvetidir");
//     break;
//   } else if (a < i) {
//     console.log("2 ededin quvveti deyil");
//   }
// }
//#endregion

//#region task3

const num = 15;
let i = 1;
let count = 0;

while (i <= num) {
  if (num % i == 0) {
    count++;
  }
  i++;
}
if (count == 2) {
  console.log("sade ededir");
} else {
  console.log("murekkeb ededir");
}
//#endregion

//#region Task4

// const month = 4;

// switch (month) {
//   case 1:
//   case 2:
//   case 3:
//     console.log("Winter");
//     break;
//   case 4:
//   case 5:
//   case 6:
//     console.log("Spring");
//     break;
//   case 7:
//   case 8:
//   case 9:
//     console.log("Summer");
//     break;
//   case 10:
//   case 11:
//   case 12:
//     console.log("Autumn");
//     break;
//   default:
//     console.log("Error");
// }

//#endregion
