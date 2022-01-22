var myData = [
    // Barisal Division has 6 Districts
    ["Barisal", "Barisal"],
    ["Barisal", "Barguna"],
    ["Barisal", "Bhola"],
    ["Barisal", "Jhalokati"],
    ["Barisal", "Patuakhali"],
    ["Barisal", "Pirojpur"],
    
    // Chittagong Division has 11 Districts
    ["Chittagong", "Chittagong"],
    ["Chittagong", "Bandarban"],
    ["Chittagong", "Brahmanbaria"],
    ["Chittagong", "Chandpur"],
    ["Chittagong", "Comilla"],
    ["Chittagong", "Cox's Bazar"],
    ["Chittagong", "Feni"],
    ["Chittagong", "Khagrachari"],
    ["Chittagong", "Lakshmipur"],
    ["Chittagong", "Noakhali"],
    ["Chittagong", "Rangamati"],
    
    // Dhaka Division has 13 Districts    
    ["Dhaka", "Dhaka"],
    ["Dhaka", "Faridpur"],
    ["Dhaka", "Gazipur"],
    ["Dhaka", "Gopalganj"],
    ["Dhaka", "Kishoreganj"],
    ["Dhaka", "Madaripur"],
    ["Dhaka", "Manikganj"],
    ["Dhaka", "Munshiganj"],
    ["Dhaka", "Narayanganj"],
    ["Dhaka", "Narsingdi"],
    ["Dhaka", "Rajbari"],
    ["Dhaka", "Shariatpur"],
    ["Dhaka", "Tangail"],
    

    // Khulna Division has 10 Districts  
    ["Khulna", "Khulna"],  
    ["Khulna", "Bagerhat"],
    ["Khulna", "Chuadanga"],
    ["Khulna", "Jessor"],
    ["Khulna", "Jhenaidah"],
    ["Khulna", "Kushtia"],
    ["Khulna", "Magura"],
    ["Khulna", "Meherpur"],
    ["Khulna", "Narail"],
    ["Khulna", "Satkhira"],

    // Mymensingh Division has 4 Districts
    ["Mymensingh", "Mymensingh"],
    ["Mymensingh", "Jamalpur"],
    ["Mymensingh", "Netrokona"],
    ["Mymensingh", "Sherpur"],

    // Rajshahi Division has 8 Districts
    ["Rajshahi", "Rajshahi"],
    ["Rajshahi", "Bogura"],
    ["Rajshahi", "Jaipurhat"],
    ["Rajshahi", "Naogaon"],
    ["Rajshahi", "Natore"],
    ["Rajshahi", "Nawabganj"],
    ["Rajshahi", "Pabna"],
    ["Rajshahi", "Sirajganj"],

    // Rangpur Division has 8 Districts
    ["Rangpur", "Rangpur"],
    ["Rangpur", "Dinajpur"],
    ["Rangpur", "Gaibandha"],
    ["Rangpur", "Kurigram"],
    ["Rangpur", "Lalmonirhat"],
    ["Rangpur", "Nilphamari"],
    ["Rangpur", "Panchagarh"],
    ["Rangpur", "Thakurgaon"],
    

    // Sylhet Division has 4 Districts
    ["Sylhet", "Sylhet"],
    ["Sylhet", "Habiganj"],
    ["Sylhet", "Moulvibazar"],
    ["Sylhet", "Sunamganj"],
];

function makeDropDown(data, level1Filter) {
    const filteredArray = data.filter(r => r[0] ===  level1Filter);

    const uniqueOptions = new Set(); 
    filteredArray.forEach(r => uniqueOptions.add(r[1]));

    const uniqueList = [...uniqueOptions];

    const selectLevel2 = document.getElementById("level2");

    selectLevel2.innerHTML = "";
    uniqueList.forEach(item => {
        const option = document.createElement("option");
        option.textContent = item; 
        selectLevel2.appendChild(option);
    });
}

function applyDropDown() {
    const selectLevel1Value = document.getElementById("level1").value;
    makeDropDown(myData, selectLevel1Value)
}

document.getElementById("level1").addEventListener("change", applyDropDown);


