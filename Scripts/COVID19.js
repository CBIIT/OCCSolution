// CONFIG FOR BANNER

(function (w, d) {
    /*console.log('hello Lawrence');*/
    w.c19 = w.c19 || {};
    w.c19.title = "COVID-19";
    w.c19.toggleLabelText = {
        expand: "Click to expand list of COVID-19 resources",
        collapse: "Click to collapse list of COVID-19 resources"
    };
    w.c19.links = [
        {
            text: "What people with cancer should know",
            url: "https://www.cancer.gov/coronavirus"
        },
        {
            text: "Guidance for cancer researchers",
            url: "https://www.cancer.gov/coronavirus-researchers"
        },
        {
            text: "Get the latest public health information from CDC",
            url: "https://www.coronavirus.gov/"
        },
        {
            text: "Get the latest research information from NIH",
            url: "https://www.nih.gov/coronavirus"
        }
    ];
})(window, document);

// BANNER FUNCTIONALITY
(function (w, d) {
    w.c19 = w.c19 || {};

    function clb(links) {
        if (!links || links.length < 1) return "";
        var link = links[0];
        return (
            "<li>" +
            ' <a href="' +
            link.url +
            '">' +
            link.text +
            "</a>" +
            "</li>" +
            clb(links.slice(1))
        );
    }

    function IS_DESKTOP() {
        return window.innerWidth > 1024;
    }

    w.c19.insert = function () {

        var wrapper = d.querySelector(".alert-drawer-wrapper");
        if (!wrapper) {
            if (wrapper) console.error("Could not find alert wrapper for banner");
            return;
        }

        var heading = d.createElement("div");
        heading.classList.add("alert-drawer__heading");
        heading.innerHTML =
            '<span class="alert-drawer-title">' + w.c19.title + "</span>";

        var linksBody = d.createElement("ul");
        linksBody.setAttribute("tabindex", "0");
        linksBody.id = "alert-drawer-body";
        linksBody.classList.add("alert-drawer__body");
        if (IS_DESKTOP()) {
            linksBody.classList.add("active");
        }
        linksBody.innerHTML = clb(w.c19.links);

        var toggleBtn = d.createElement("button");
        toggleBtn.setAttribute("type", "button");
        toggleBtn.setAttribute("aria-controls", "alert-drawer-body");
        toggleBtn.id = "alert-toggle-btn"; // Desktop shows X, but mobile and collapsed is down arrow.
        var isExpanded = IS_DESKTOP();
        var toggleBtnImg = isExpanded
            ? "https://www.cancer.gov/sites/g/files/xnrzdm211/files/cgov_contextual_image/2020-03/white-x.png"
            : "https://www.cancer.gov/sites/g/files/xnrzdm211/files/cgov_contextual_image/2020-03/white-down-arrow.png";
        toggleBtn.setAttribute(
            "aria-label",
            isExpanded ? w.c19.toggleLabelText.collapse : w.c19.toggleLabelText.expand
        );
        toggleBtn.setAttribute("aria-expanded", isExpanded ? "true" : "false");
        toggleBtn.innerHTML =
            '<img id="alert-toggle-img" src="' +
            toggleBtnImg +
            '" alt="" aria-hidden="true" />';
        toggleBtn.addEventListener("click", function () {
            var alertBody = document.querySelector(".alert-drawer__body");
            var wasOpen = alertBody.classList.contains("active"); //toggle aria-expanded, this being the toggleBtn
            this.setAttribute("aria-expanded", wasOpen ? "false" : "true");
            this.setAttribute(
                "aria-label",
                wasOpen ? w.c19.toggleLabelText.expand : w.c19.toggleLabelText.collapse
            );

            var alertDrawer = document.querySelector(".alert-drawer");
            alertDrawer.classList.toggle("expanded");
            alertDrawer.classList.toggle("collapsed");

            var alertImg = "";
            alertBody.classList.toggle("active");
            if (alertBody.className.match("active")) {
                alertBody.focus();
                alertImg =
                    "https://www.cancer.gov/sites/g/files/xnrzdm211/files/cgov_contextual_image/2020-03/white-x.png";
            } else {
                alertImg =
                    "https://www.cancer.gov/sites/g/files/xnrzdm211/files/cgov_contextual_image/2020-03/white-down-arrow.png";
            }
            document.getElementById("alert-toggle-img").setAttribute("src", alertImg);
        });

        var toggle = d.createElement("div");
        toggle.classList.add("alert-drawer__toggle");
        toggle.appendChild(toggleBtn);
        var drawer = d.createElement("ul");
        drawer.classList.add("alert-drawer"); // Launch adds default styles, but we should also set the state of the // drawer on initialize.
        if (IS_DESKTOP()) {
            drawer.classList.add("expanded");
        }
        drawer.appendChild(heading);
        drawer.appendChild(linksBody);
        drawer.appendChild(toggle);

        wrapper.innerHTML = "";
        wrapper.appendChild(drawer);
    };
})(window, document);

window.c19.insert();
