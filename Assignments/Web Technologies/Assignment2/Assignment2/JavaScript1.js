/*************************************************
  1. Area of a triangle (sides: 5, 6, 7)
*************************************************/
let a = 5;
let b = 6;
let c = 7;

let s = (a + b + c) / 2; // semi-perimeter
let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));

console.log("1. Area of the triangle:", area);


/*************************************************
  2. Star pattern using nested for loop
*************************************************/
console.log("\n2. Star Pattern:");

let rows = 5;
for (let i = 1; i <= rows; i++) {
    let pattern = "";
    for (let j = 1; j <= i; j++) {
        pattern += "* ";
    }
    console.log(pattern);
}


/*************************************************
  3. Leap year check
*************************************************/
let year = 2024;

if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {
    console.log("\n3. " + year + " is a leap year");
} else {
    console.log("\n3. " + year + " is not a leap year");
}


/*************************************************
  4. Days left until Independence Day (Aug 15)
*************************************************/
let today = new Date();
let currentYear = today.getFullYear();

// August is month 7 (0-based index)
let independenceDay = new Date(currentYear, 7, 15);

// If today is past August 15, move to next year
if (today > independenceDay) {
    independenceDay = new Date(currentYear + 1, 7, 15);
}

let timeDifference = independenceDay - today;
let daysLeft = Math.ceil(timeDifference / (1000 * 60 * 60 * 24));

console.log("\n4. Days left until Independence Day:", daysLeft);
