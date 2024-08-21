//creating a constructor is best practice and makes it easier to work with the person object since
//we can can create an empty object and still refer to all the fields as well as change 
//them step for step, it also makes error handling easier
function Person(firstName, lastName, email, userID, country, state, city, phone, referenceCode) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.userID = userID;
    this.country = country;
    this.state = state;
    this.city = city;
    this.phone = phone;
    this.referenceCode = referenceCode;
  }

  function lettersOnly(input) {
    let numbersArray = ['0','1','2','3','4','5','6','7','8','9'];
    let specialArray = ['!','@','#','$','%','^','&','*','(',')','_','+','=','`','~',',','<','>','.','/','?','|'];
    for(let i = 0; i < input.length; i++){
        //console.log(`${input[i]} is ${typeof(input[i])}`)
        if(numbersArray.includes(input[i]) || specialArray.includes(input[i])){
            alert(`${input} is an invalid text field.`); 
            return false;
        }
    }
    return true;
  }

  function numbersOnly(input) {   
    let alphabet = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    let specialArray = ['!','@','#','$','%','^','&','*','(',')','_','+','=','`','~',',','<','>','.','/','?','|'];
    let counter = 0;
    for(let i = 0; i < input.length; i++, counter++){
        //console.log(`${input[i]} is ${typeof(input[i])}`);
        if(alphabet.includes(input[i]) || specialArray.includes(input[i])){
            alert(`Phone number has an invalid character.`);
            return false;
        };    
    }
    return true;

  }

  function emailValid(input) {
    if(input.includes('@')){
        let [test, domain] = input.split('@');
        if(test.length <= 3){
            alert("Email must have more than 3 characters before '@' sign.");
            return false;
        }
        if(!domain.includes('.')){
            alert("Domain must contain a '.' character.");
            return false;
        }
    }else{
      alert("Email must contain '@' character.");
      return false;
    };     
    return true;
  }

  document.addEventListener("DOMContentLoaded", function() {
    // Automatically generate a random reference code on page load
    const randomReference = generateRandomReference(10);
    document.getElementById("reference-code").value = randomReference;
  
    
  
      // Get the user-entered reference code
      const userReferenceCode = document.getElementById("reference-code").value;
  
      // Check if the user's reference code matches the generated reference
      if (userReferenceCode === randomReference) {
        // Reference code is valid
        console.log("Reference code is valid!");
        // Perform any actions you want for a valid reference code here
      } else {
        // Reference code is invalid
        console.log("Invalid reference code. Please try again.");
        // Perform any actions you want for an invalid reference code here
      }
    });
  ;
  
  // Function to generate a random reference code
  function generateRandomReference(length) {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let reference = '';
  
    for (let i = 0; i < length; i++) {
      const randomIndex = Math.floor(Math.random() * characters.length);
      reference += characters.charAt(randomIndex);
    }
  
    return reference;
  }
  


  let firstNameValid=false;
  let lastNameValid=false;
  let emailIDValid=false;
  let phoneValid=false;
  let refrenceCodeValid=false;

  function formValid() {
    if (firstNameValid&&
      lastNameValid&&
      emailIDValid&&
      phoneValid) {

      return true;
    }
    else{
      return false;
    } 
    
  }

 

  //this will be our global refrence code which wil be regenerated every
  //time we click in the refrence code input box
  let referenceCode;

  //this wil be our global person which will store all our inputed values
  let globalPerson= new Person();


  //the following code is adding event listners to each input field and processing
  //the info typed in
  //each text field has the "blur" listener since we want to check and add the values
  //after the person finished typing it in
  document.getElementById("first-name").addEventListener("blur", function() {
    globalPerson.firstName= document.getElementById('first-name').value;

    document.getElementById("first-name-label").classList.remove("text-primary");
    document.getElementById("first-name").classList.remove("border-primary");

    if(lettersOnly(globalPerson.firstName)&&globalPerson.firstName.length>1){
      firstNameValid=true;
      document.getElementById("first-name").classList.remove("border-danger", "border-top");
    }else{
      firstNameValid=false;
      document.getElementById("first-name").classList.add("border-danger", "border-top");
    }

    if (formValid) {
      document.getElementById("continue-button").removeAttribute('disabled');
    }else{
      document.getElementById("continue-button").setAttribute('disabled', 'true');
    }
  });

  document.getElementById("last-name").addEventListener("blur", function() {
    globalPerson.lastName= document.getElementById("last-name").value;

    document.getElementById("lastname").classList.remove("text-primary");
    document.getElementById("last-name").classList.remove("border-primary");

    if(lettersOnly(globalPerson.lastName)&&globalPerson.lastName.length>1){
      firstNameValid=true;
      document.getElementById("last-name").classList.remove("border-danger", "border-top");
    }else{
      firstNameValid=false;
      document.getElementById("last-name").classList.add("border-danger", "border-top");
    }

    if (formValid) {
      document.getElementById("continue-button").removeAttribute('disabled');
    }else{
      document.getElementById("continue-button").setAttribute('disabled', 'true');
    }
  });

  document.getElementById("email").addEventListener("blur", function() {
    globalPerson.email= document.getElementById("email").value;

    document.getElementById("email2").classList.remove("text-primary");
    document.getElementById("email").classList.remove("border-primary");

    if(emailValid(globalPerson.email)){
      firstNameValid=true;
      document.getElementById("email").classList.remove("border-danger", "border-top");
      document.getElementById('check-mark').removeAttribute("hidden",false);
    }else{
      firstNameValid=false;
      document.getElementById("email").classList.add("border-danger", "border-top");
      document.getElementById('check-mark').setAttribute('hidden', 'true');
    }

    if (formValid) {
      document.getElementById("continue-button").removeAttribute('disabled');
    }else{
      document.getElementById("continue-button").setAttribute('disabled', 'true');
    }
  });


  document.getElementById("user-id").addEventListener("blur", function() {
    globalPerson.userID= document.getElementById("user-id").value;
    
    document.getElementById("userid").classList.remove("text-primary");
    document.getElementById("user-id").classList.remove("border-primary");
    
    if(globalPerson.userID.length>1){
      firstNameValid=true;
      document.getElementById("user-id").classList.remove("border-danger", "border-top");
    }else{
      firstNameValid=false;
      document.getElementById("user-id").classList.add("border-danger", "border-top");
    }

    if (formValid) {
      document.getElementById("continue-button").removeAttribute('disabled');
    }else{
      document.getElementById("continue-button").setAttribute('disabled', 'true');
    }

  });

  document.getElementById("country").addEventListener("blur", function() {

    globalPerson.country= document.getElementById("country").value
  
    document.getElementById("Country2").classList.remove("text-primary");
    document.getElementById("country").classList.remove("border-primary");
  
  });

  document.getElementById("state").addEventListener("blur", function() {
    globalPerson.state= document.getElementById("state").value
  
    document.getElementById("state2").classList.remove("text-primary");
    document.getElementById("state").classList.remove("border-primary");
  
  });

  document.getElementById("city").addEventListener("blur", function() {
    globalPerson.city= document.getElementById("city").value
  
    document.getElementById("city2").classList.remove("text-primary");
    document.getElementById("city").classList.remove("border-primary");
  
  });

  document.getElementById("phone").addEventListener("blur", function() {
    globalPerson.phone= document.getElementById("phone").value;

    document.getElementById("phone2").classList.remove("text-primary");
    document.getElementById("phone").classList.remove("border-primary");

    if(numbersOnly(globalPerson.phone)&& globalPerson.phone.length==10){
      firstNameValid=true;
      document.getElementById("phone").classList.remove("border-danger", "border-top");
    }else{
      firstNameValid=false;
      document.getElementById("phone").classList.add("border-danger", "border-top");
    }

    if (formValid) {
      document.getElementById("continue-button").removeAttribute('disabled');
    }else{
      document.getElementById("continue-button").setAttribute('disabled', 'true');
    }
  });
   
  document.getElementById("reference-code").addEventListener("blur", function() {

    globalPerson.referenceCode= document.getElementById("reference-code").value;

    document.getElementById("reference-code2").classList.remove("text-primary");
    document.getElementById("reference-code").classList.remove("border-primary");

    randomRefrence();

    if (formValid) {
      document.getElementById("continue-button").removeAttribute('disabled');
    }else{
      document.getElementById("continue-button").setAttribute('disabled', 'true');
    }
  });

  document.getElementById("first-name").addEventListener("focus", function(){
    document.getElementById("first-name-label").classList.add("text-primary");
    document.getElementById("first-name").classList.add("border-primary");
  });
  document.getElementById("last-name").addEventListener("focus", function(){
    document.getElementById("lastname").classList.add("text-primary");
    document.getElementById("last-name").classList.add("border-primary");
  });
  document.getElementById("email").addEventListener("focus", function(){
    document.getElementById("email2").classList.add("text-primary");
    document.getElementById("email").classList.add("border-primary");
  });
  document.getElementById("user-id").addEventListener("focus", function(){
    document.getElementById("userid").classList.add("text-primary");
    document.getElementById("user-id").classList.add("border-primary");
  });
  document.getElementById("country").addEventListener("focus", function(){
    document.getElementById("Country2").classList.add("text-primary");
    document.getElementById("country").classList.add("border-primary");
  });
  document.getElementById("state").addEventListener("focus", function(){
    document.getElementById("state2").classList.add("text-primary");
    document.getElementById("state").classList.add("border-primary");
  });
  document.getElementById("city").addEventListener("focus", function(){
    document.getElementById("city2").classList.add("text-primary");
    document.getElementById("city").classList.add("border-primary");
  });
  document.getElementById("phone").addEventListener("focus", function(){
    document.getElementById("phone2").classList.add("text-primary");
    document.getElementById("phone").classList.add("border-primary");
  });
  document.getElementById("reference-code").addEventListener("focus", function(){
    document.getElementById("reference-code2").classList.add("text-primary");
    document.getElementById("reference-code").classList.add("border-primary");
  });


  document.getElementById("reset").addEventListener("click", function() {
    resetForm();});

    function resetForm(){
      document.getElementById("first-name").value = '';
      document.getElementById("last-name").value = '';
      document.getElementById("email").value = '';
      document.getElementById("user-id").value = '';
      document.getElementById("phone").value = '';
      document.getElementById("reference-code").value = '';
    } 
    // The function resetForm is created to clear all fields.
    //const params = new URLSearchParams(window.location.search);
    function displaySummary(){
      const params = new URLSearchParams(window.location.search);
      document.getElementById("first-name").textContent = params.get('first-name');
      document.getElementById("last-name").textContent = params.get('last-name');
      document.getElementById("email").textContent = params.get('email');
      document.getElementById("user-id").textContent = params.get('user-id');
      document.getElementById("country").textContent = params.get('country');
      document.getElementById("city").textContent = params.get('city');
      document.getElementById("state").textContent = params.get('state');
      document.getElementById("phone").textContent = params.get('phone');
      document.getElementById("reference-code").textContent = params.get('reference-code');
    }

