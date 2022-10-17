let index = 0;

function AddTag() {
    // get a reference to the TagEntry input element
    var tagEntry = document.getElementById("TagEntry");

    // lets use the new search function to help detect an error state
    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        // Trigger my sweet alert
        Swal.fire({
            title: "Error!",
            text: 'Do you want to continue?',
            icon: 'error',
            confirmButtonText:'Cool'
        })


    }
    else {
        // Create a new select option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }

    // clear out the tagEntry control

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

$("form").on("submit", function (){
    $("#TagList option").prop("selected", "selected");
})


// Look for the tagValues variable to see if it has data

if (tagValues !='') {
    let tagArray = tagValues.split(",");

    for (let loop = 0; loop < tagArray.length; loop++){
        //Load up or replace the options that we have
        ReplaceTag(tagArray[loop], loop);

        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;

}

/// the search function will detect either an empty or a duplicate Tag
// and return an Error string if an error is detected

function search(str) {
    if (str == "") {
        return 'Empty Tags are not permitted';
    }

    var tagsEl = document.getElementById('TagList');

    if (tagsEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value == str)
                return String.Format("The Tag {0} was detected as a duplicate tags are not permitted",str);
            
        }
    }

}