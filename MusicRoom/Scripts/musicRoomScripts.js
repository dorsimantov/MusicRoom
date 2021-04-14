//FUNCTION ADDS ELEMENTS TO LISTS IN NEWBAND FORM
    function elementAdder(inputId, listTd) {
            if (document.getElementById(inputId).value.trim() != "") {
                if (document.getElementById(document.getElementById(inputId).value) == null) {
                    //Add element
                    //counts how many of this object exist
                    var count = document.getElementById(inputId + "Counter");
                    //div resembles the element itself
                    var div = document.createElement('td');
                    //hidden is a hidden field that passes the data to the controller later
                    var hidden = document.createElement('input');
                    hidden.type = "hidden";
                    if (inputId == "Users") {
                        hidden.name = inputId + "[" + count + "].Username";
                    }
                    else {
                        hidden.name = inputId + "[" + count + "].Name";
                    }
                    
                    div.className = "listElement";
                    div.id = document.getElementById(inputId).value;
                    div.innerHTML = document.getElementById(inputId).value;
                    document.getElementById(listTd).appendChild(div);
                    document.getElementById(inputId).value = "";
                    document.getElementById(inputId + "Counter").value++;
                    //Remove element:
                    div.onclick = function () {
                     this.parentNode.removeChild(this);
                    }
                }
            }
    }