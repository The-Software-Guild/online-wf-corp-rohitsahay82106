$(document).ready(function () {
    loadItems();
    var totalMoney = 0;   

    //This section contains routing for adding money related buttons 
	$("#addDollar").on("click", function () {	
        addMoney(1.00);
	});
    $("#addQuarter").on("click", function () {
		addMoney(0.25);
	});
    $("#addDime").on("click", function () {
		addMoney(0.10);
    });
    $("#addNickel").on("click", function () {
		addMoney(0.05);
		
    });
	
	//This section contains routing for clicking on the individual vending items	
	$(document).on('click',".card",function(){
		
		var num = $(this).children("#itemID").text();
		
		$("#inputItem").val(num);
		
		$('#totalChange').val("");
		$('#Messages').val("");
	});
	
	//This section contains routing for making purchase 
	$("#make-purchase-button").on("click", function () {
        totalMoney = parseFloat($("#totalDeposit").attr("value"));
        makePurchase(totalMoney);
        
    });

	//This section contains routing for cancelling a transaction via change return button
    $("#return-change-button").on("click", function () {
        totalMoney = parseFloat($("#totalDeposit").attr("value"));
		returnChange(totalMoney);
    });


});

function loadItems() {
    clearItemLists();

    var itemList = $('#itemList');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (data, status) {
            $.each(data, function (index, item) {
                var itemID = item.id;
                var itemName = item.name;
                var itemPrice = item.price;
                var itemQty = item.quantity;

                var row = '<div class="col-sm-4">' + '<div class="card">';
                row += '<p class="card-header text-left font-weight-bold" id="itemID">' + itemID + '</p>';
                row += '<div class="card-body">' + '<div class="card-title">';
                row += '<p class="text-center">' + itemName + '</p></div>';
                row += '<div class="card-text"><p class="text-center">$' + itemPrice + '</p></div></div>';
                row += '<p class="card-footer text-center">Quantity Left: ' + itemQty +'</p></div></div>';
                itemList.append(row);
            });
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service.  Please try again later.'));
        }
    });
};

function makePurchase(totalMoney) {
    $('#totalChange').empty();
    $('#Messages').empty();

    var successfulPurchase = false;
    var totalChange = '';
    var itemID = $("#inputItem").val();
	var errorMessage = "";
    
	if (itemID==""){
		$('#Messages').val('Please select an item');
		return;
	};
	
	
	$.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + totalMoney + '/item/' + itemID,
        success: function (data, status) {

            if (data.quarters > 0) {
                totalChange += data.quarters + ' quarter ';
            }
            if (data.dimes > 0) {
                totalChange += data.dimes + ' dime ';
            }
            if (data.nickels > 0) {
                totalChange += data.nickels + ' nickel ';
            }
            if (data.pennies > 0) {
                totalChange += data.pennies + ' penny ';
            }

            
            $("#Messages").val('Thank You!!!');
			$("#totalChange").val(totalChange);
			loadItems();
			totalMoney = 0;
            $("#totalDeposit").attr("value",totalMoney.toFixed(2));
			$("#return-change-button").hide();
                      
            
        },
        error: function (jqXHR, error, errorThrown) {
             errorMessage = $.parseJSON(jqXHR.responseText).message;
             $("#Messages").val(errorMessage);
			 $("#return-change-button").show();
        }
        
    });

 

};

function returnChange(totalMoney) {
   var totalChange = '';
   if(totalMoney==0){
		$("#Messages").val('There is no money to be returned!');
		$("#inputItem").val("");
		$("#totalChange").val(totalChange);
		return;
   };
   

    var totalQuarters = (totalMoney - (totalMoney % 0.25)) / 0.25;
    var moneyLeft = totalMoney % 0.25;

    if (moneyLeft > 0.09) {
        var totalDimes = (moneyLeft - (moneyLeft % 0.10)) / 0.10;
        var moneyLeft = totalMoney % 0.10;
    };
    if (moneyLeft > 0) {
        var totalNickels = (moneyLeft - (moneyLeft % 0.05)) / 0.05;
        var moneyLeft = totalMoney % 0.05;
    };

        if (totalQuarters > 0) {
            totalChange += totalQuarters + ' quarter ';
        }
        if (totalDimes > 0) {
            totalChange += totalDimes + ' dime ';
        }
        if (totalNickels > 0) {
            totalChange += totalNickels + ' nickel ';
        }
    
		$("#Messages").val('Please collect your change, Thank You!!');
		$("#totalChange").val(totalChange);
		totalMoney = 0;
        $("#totalDeposit").attr("value",totalMoney.toFixed(2));
		$("#inputItem").val("");
		$("#return-change-button").hide();

        

};

function addMoney(depositValue){
		totalMoney=parseFloat($("#totalDeposit").attr("value"));
       
		totalMoney += depositValue;

		$("#totalDeposit").attr("value",totalMoney.toFixed(2));
        $('#totalChange').val("");
		$("#return-change-button").show();
};

function clearItemLists() {
    $('#itemList').empty();
};




