
let index = 0;

function AddTag() {
    // Get a reference to the TagEntry input element
    var tagEntry = document.getElementById("TagEntry");

    // Lets use the new search function to help detect an error state

    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        // Trigger my sweet alert for the empty string
        swalWithDarkButton.fire({
            html: '<span class='font-weight-bolder'>${ searchResult.toUpperCase() }</span>'

        });
    }
    else {
        // Create a new select option

        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    } 

    // Clear out the TagEntry control

    tagEntry.value = "";
    return true;

}

function DeleteTag() {
    let tagCount = 1;
    while (tagCount > 0) {
        let tagList = document.getElementById("TagList");

        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            tagList.options[selectedIndex] = null;
            --tagCount;
        }
        else
            tagCount = 0;
        index--;
    }
}


$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");

})

// Look for the tagValues variable to see if it has data
if (tagValues != "") {
    let tagArray = tagValues.split(",");

    for (let loop = 0; loop < tagArray.length; loop++) {
        //Load up or replace the options that we have
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

// The search function will detect either an empty or a duplicate tag
// and return an error string if an error is detected
function search(str) {
    if (str == "") {
        return "Empty tags are not permitted";
    }
    var tagsEl = document.getElementById('TagList');

    if (tagsEl) {
        let options = tagsEl.options;
        for (let i = 0; i < options.length; i++) {
            if (options[i].value == str) {
                return 'The Tags were detected as a duplication and not permitted'
            }
        }
    }

}

const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger btn-sm btn-block btn-outline-dark'
    },

    timer: 3000,
})