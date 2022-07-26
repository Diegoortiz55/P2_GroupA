var updateRankings = function () {

    var updateRank = function (p, e, rank) {

        var $resultUpdate = $('#portfolioModal1Name');
        $resultUpdate = $(`#portfolioModal${rank}Name`);

        $resultUpdate.empty();
        $resultUpdate.append(`${p.productName}`);

        $resultUpdate = $(`#portfolioModal${rank}ShortDescription`);
        $resultUpdate.empty();
        $resultUpdate.append(`${e.productShortDescription}`);

        $resultUpdate = $(`#portfolioModal${rank}Image1`);
        $resultUpdate.empty();
        $resultUpdate.append(`<img class="img-fluid" src="${e.productImagePath}" alt="..." />`);

        $resultUpdate = $(`#portfolioModal${rank}Image2`);
        $resultUpdate.empty();
        $resultUpdate.append(`<img class="img-fluid" src="${e.productImagePath}" alt="..." />`);

        $resultUpdate = $(`#portfolioModal${rank}Developer`);
        $resultUpdate.empty();
        $resultUpdate.append(`${p.productManufacturer}`);

        $resultUpdate = $(`#portfolioModal${rank}NamewDate`);
        $resultUpdate.empty();
        const date = new Date(p.productReleaseDate);
        $resultUpdate.append(`${p.productName} (${date.getFullYear()})`);

        $resultUpdate = $(`#portfolioModal${rank}Review`);
        $resultUpdate.empty();
        $resultUpdate.append(`${e.productReview}`);

        $resultUpdate = $(`#portfolioModal${rank}Description`);
        $resultUpdate.empty();
        $resultUpdate.append(`${e.productDescription}`);

        $resultUpdate = $(`#portfolioModal${rank}ReleaseDate`);
        $resultUpdate.empty();
        $resultUpdate.append(`${date.toLocaleDateString()}`);

    }

    //
    // Get the additional Information that we are storing
    // on the client side.
    // 
    var extraProductInfo = [];
    $.getJSON("assets/extraProductInfo.json", function (data) {
        //return data;
        $.each(data, function (key, val) {
            extraProductInfo.push(val);
        });
    });

    console.log(extraProductInfo);

    //
    // Get all the Products Information via the api
    //
    let productInfoesAPI = 'api/TblProductInfoes';
    let request = new XMLHttpRequest();
    request.open('GET', productInfoesAPI);
    request.send();
    request.addEventListener('load', function () {
        let productArray = JSON.parse(request.responseText);
        console.log(productArray);

        //
        // Get all of the ranking information via api
        //
        let productRankingsAPI = 'api/TBLProductRankings';
        let requestR = new XMLHttpRequest();
        requestR.open('GET', productRankingsAPI);
        requestR.send();
        requestR.addEventListener('load', function () {
            let rankingsArray = JSON.parse(requestR.responseText);
            console.log(rankingsArray);
            //
            // For each ranking
            $.each(rankingsArray, function (i, ranking) {
                //
                // Find the product info for that ranking
                //
                var foundProduct = $.grep(productArray, function (n, i) {
                    return n.productName == ranking.productName;
                });
                //
                // Find any extra client side information for that ranking
                //
                var foundExtraInfo = $.grep(extraProductInfo, function (n, i) {
                    return n.productName == ranking.productName;
                });
                //console.log(foundProduct);
                //console.log(foundExtraInfo);
                updateRank(foundProduct[0], foundExtraInfo[0], ranking.productRanking)
            });
        });

    });

 
};