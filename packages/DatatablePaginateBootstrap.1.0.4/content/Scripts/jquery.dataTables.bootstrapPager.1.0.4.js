
$.fn.dataTableExt.oPagination.bootstrapPager = {
    "fnInit": function (oSettings, nPaging, fnCallbackDraw) {

        //console.log(oSettings);
        if (oSettings.sTableId == '') {
            alert("DEVELOPER:  YOU MUST SET AN ID ON THE DATATABLE FOR THE PAGER TO WORK");
            return;
        }


        var nFirst = $("<span />");
        var nPrevious = $("<span />");
        var nNext = $("<span />");
        var nLast = $("<span />");


        var nTextbox = $('<input type="text" />');
        var nTextboxPrefix = $('<span />');
        var nTextboxSuffix = $("<span />");
        var dFirst = $("<span />");
        var dNext = $("<span />");
        var dPrevious = $("<span />");
        var dLast = $("<span />");

        var pgLabel = $("<label />");


        nFirst.addClass("paginate_button paginate_button_first");
        nPrevious.addClass("paginate_button  paginate_button_previous");
        nNext.addClass("paginate_button paginate_button_next");
        nLast.addClass("paginate_button paginate_button_last");


        //In case you want to use your own CSS to override my defaults font-size and widths
        nTextboxPrefix.addClass("paginate_prefix");
        nTextboxSuffix.addClass("paginate_suffix")
        nTextbox.addClass("paginate_textbox");


        //these span icons will be hidden by default
        dFirst.addClass("paginate_button_first_disabled hide");
        dPrevious.addClass("paginate_button_previous hide");
        dNext.addClass("paginate_button_next_disabled hide");
        dLast.addClass("paginate_button_last hide");

        //nFirst, nPrevious, nNext and nLast get some additional styling from the datatable css file:  .dataTables_wrapper .dataTables_paginate .paginate_button
        //Let's mimick that.  We don't want to use the same classes because they have a hover effect that shouldn't exist for disabled buttons.
        dFirst.css('width', 44)
            .css('text-align', 'center')
            .css('padding-left', 14)
            .css('padding-right', 14)
            .css('margin-left', 2);

        dPrevious.css('width', 44)
            .css('text-align', 'center')
            .css('padding-left', 14)
            .css('padding-right', 14)
            .css('margin-left', 2);

        dNext.css('width', 44)
            .css('text-align', 'center')
            .css('padding-left', 14)
            .css('padding-right', 14)
            .css('margin-left', 2);

        dLast.css('width', 44)
            .css('text-align', 'center')
            .css('padding-left', 14)
            .css('padding-right', 14)
            .css('margin-left', 2);

        //make the icons look disabled
        dFirst.css('color', '#CCC');
        dNext.css('color', '#CCC');
        dPrevious.css('color', '#CCC');
        dLast.css('color', '#CCC');

        pgLabel.css("font-weight", "normal");



        //Setting an id
        $(nPaging).attr('id', oSettings.sTableId + '_paginate');

        nFirst.attr('id', oSettings.sTableId + '_paginate_button_first');
        nPrevious.attr('id', oSettings.sTableId + '_paginate_button_previous');
        nNext.attr('id', oSettings.sTableId + '_paginate_button_next');
        nLast.attr('id', oSettings.sTableId + '_paginate_button_last');

        dFirst.attr('id', oSettings.sTableId + '_paginate_button_first_disabled');
        dPrevious.attr('id', oSettings.sTableId + '_paginate_button_previous_disabled');
        dNext.attr('id', oSettings.sTableId + '_paginate_button_next_disabled');
        dLast.attr('id', oSettings.sTableId + '_paginate_button_last_disabled');

        nTextbox.attr("id", oSettings.sTableId + "_paginate_textbox");
        nTextboxSuffix.attr('id', oSettings.sTableId + '_paginate_suffix');
        nTextboxPrefix.attr('id', oSettings.sTableId + '_paginate_prefix');

        //styling the input
        nTextbox.addClass("form-control")
            .css("width", 45)
            .css("display", "inline");


        nTextboxPrefix.html("Page")
            .css('padding-right', 3);


        $(pgLabel).append(nTextboxPrefix)
            .append(nTextbox)
            .append(nTextboxSuffix);


        //adding the elements to the pager
        $(nPaging).append(nFirst)
            .append(dFirst)
            .append(nPrevious)
            .append(dPrevious)
            .append(pgLabel)
            .append(nNext)
            .append(dNext)
            .append(nLast)
            .append(dLast);


        //Make the icons clickable
        nFirst.click(function () {
            oSettings.oApi._fnPageChange(oSettings, "first");
            fnCallbackDraw(oSettings);
        });

        nPrevious.click(function () {
            oSettings.oApi._fnPageChange(oSettings, "previous");
            fnCallbackDraw(oSettings);
        });

        nNext.click(function () {
            oSettings.oApi._fnPageChange(oSettings, "next");
            fnCallbackDraw(oSettings);
        });

        nLast.click(function () {
            oSettings.oApi._fnPageChange(oSettings, "last");
            fnCallbackDraw(oSettings);
        });


        //only type numbers (no negatives)
        nTextbox.keypress(function (e) {
            var e = window.event || e;
            var keyunicode = e.charCode || e.keyCode;
            if (String.fromCharCode(keyunicode).match(/[^0-9]/g)) {
                return false;
            }
        });


        //Type a number in the textbox followed by ENTER to navigate to that page
        //If drag and dropping or copy and pasting you still need to press ENTER.
        nTextbox.keyup(function (e) {
            if (e.which != 13) {
                return;
            }

            var iNewStart = oSettings._iDisplayLength * (this.value - 1);
            if (iNewStart > oSettings.fnRecordsDisplay()) {

                oSettings._iDisplayStart = (Math.ceil((oSettings.fnRecordsDisplay() - 1) /
					oSettings._iDisplayLength) - 1) * oSettings._iDisplayLength;
                fnCallbackDraw(oSettings);
                return;
            }

            oSettings._iDisplayStart = iNewStart;
            fnCallbackDraw(oSettings);
        });


    },


    //Called each time the grid is updated (i.e., length changed)
    "fnUpdate": function (oSettings, fnCallbackDraw) {
        if (!oSettings.aanFeatures.p) {
            return;
        }
        if (oSettings.sTableId == '') {
            return;
        }

        var iPages;
        if (oSettings._iDisplayLength == -1) {
            iPages = 1;
        } else {
            iPages = Math.ceil((oSettings.fnRecordsDisplay()) / oSettings._iDisplayLength);
        }
        var iCurrentPage = 0;

        if (iPages != 0) {
            iCurrentPage = Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength) + 1;
        }

        var toggleVisibility = true;
        var textboxWidth = 45;
        var nextIcon = "glyphicon glyphicon-chevron-right";
        var previousIcon = "glyphicon glyphicon-chevron-left";
        var firstIcon = "glyphicon glyphicon-step-backward";
        var lastIcon = "glyphicon glyphicon-step-forward";
        if ("pagerSettings" in oSettings.oInit) {
            //if ("toggleVisibility" in oSettings.oInit.pagerSettings) {
            //    toggleVisibility = oSettings.oInit.pagerSettings.toggleVisibility;
            //}
            if ("textboxWidth" in oSettings.oInit.pagerSettings) {
                textboxWidth = oSettings.oInit.pagerSettings.textboxWidth;
            }
            if ("nextIcon" in oSettings.oInit.pagerSettings) {
                nextIcon = oSettings.oInit.pagerSettings.nextIcon;
            }
            if ("previousIcon" in oSettings.oInit.pagerSettings) {
                previousIcon = oSettings.oInit.pagerSettings.previousIcon;
            }
            if ("firstIcon" in oSettings.oInit.pagerSettings) {
                firstIcon = oSettings.oInit.pagerSettings.firstIcon;
            }
            if ("lastIcon" in oSettings.oInit.pagerSettings) {
                lastIcon = oSettings.oInit.pagerSettings.lastIcon;
            }
        }


        var pager = $("#" + oSettings.sTableId + '_paginate');
        var textbox = $("#" + oSettings.sTableId + '_paginate_textbox');
        var textboxPrefix = $("#" + oSettings.sTableId + '_paginate_prefix');
        var textboxSuffix = $("#" + oSettings.sTableId + '_paginate_suffix');
        var nFirst = $('#' + oSettings.sTableId + '_paginate_button_first');
        var nPrevious = $('#' + oSettings.sTableId + '_paginate_button_previous');
        var nNext = $('#' + oSettings.sTableId + '_paginate_button_next');
        var nLast = $('#' + oSettings.sTableId + '_paginate_button_last');
        var dFirst = $('#' + oSettings.sTableId + '_paginate_button_first_disabled');
        var dPrevious = $('#' + oSettings.sTableId + '_paginate_button_previous_disabled');
        var dNext = $('#' + oSettings.sTableId + '_paginate_button_next_disabled');
        var dLast = $('#' + oSettings.sTableId + '_paginate_button_last_disabled');


        textbox.css("width", textboxWidth);

        if (firstIcon == "") {
            nFirst.hide();
            dFirst.hide();
        } else {
            nFirst.addClass(firstIcon);
            dFirst.addClass(firstIcon);
        }
        if (nextIcon == "") {
            nNext.hide();
            dNext.hide();
        } else {
            nNext.addClass(nextIcon);
            dNext.addClass(nextIcon);
        }
        if (previousIcon == "") {
            nPrevious.hide();
            dPrevious.hide();
        } else {
            nPrevious.addClass(previousIcon);
            dPrevious.addClass(previousIcon);
        }
        if (lastIcon == "") {
            nLast.hide();
            dLast.hide();
        } else {
            nLast.addClass(lastIcon);
            dLast.addClass(lastIcon);
        }





        if ((iCurrentPage == 1) && (iPages > 1)) {
            /* DISPLAYING THE FIRST PAGE */
            nFirst.addClass('hide');
            nPrevious.addClass('hide');
            nNext.removeClass('hide');
            nLast.removeClass('hide');

            dFirst.removeClass('hide');
            dPrevious.removeClass('hide');
            dNext.addClass('hide');
            dLast.addClass('hide');

            textbox.removeAttr('readonly');
            pager.show();

        } else if ((iCurrentPage > 1) && (iCurrentPage < iPages)) {
            /* IN BETWEEN THE FIRST AND LAST PAGE */
            nFirst.removeClass('hide');
            nPrevious.removeClass('hide');
            nNext.removeClass('hide');
            nLast.removeClass('hide');

            dFirst.addClass('hide');
            dPrevious.addClass('hide');
            dNext.addClass('hide');
            dLast.addClass('hide');

            textbox.removeAttr('readonly');
            pager.show();

        } else if ((iCurrentPage == iPages) && (iPages > 1)) {
            /* DISPLAYING THE LAST PAGE */
            nFirst.removeClass('hide');
            nPrevious.removeClass('hide');
            nNext.addClass('hide');
            nLast.addClass('hide');

            dFirst.addClass('hide');
            dPrevious.addClass('hide');
            dNext.removeClass('hide');
            dLast.removeClass('hide');

            textbox.removeAttr('readonly');
            pager.show();

        } else {
            /* DISPLAYING ALL RECORDS ON A SINGLE PAGE */
            nFirst.addClass('hide');
            nPrevious.addClass('hide');
            nNext.addClass('hide');
            nLast.addClass('hide');

            dFirst.removeClass('hide');
            dPrevious.removeClass('hide');
            dNext.removeClass('hide');
            dLast.removeClass('hide');

            textbox.attr('readonly', 'readonly');  //don't allow them to alter the number.  It should remain 1 of 1.
            if ((toggleVisibility) && (iPages == 0)) {
                pager.hide();
            }
        }


        //Updating the number of pages and the number in the textbox (if necessary)
        textboxSuffix.html(" of " + ("" + iPages).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + " pages");  //adding commmas to large numbers
        textbox.val(iCurrentPage);
    }
};


