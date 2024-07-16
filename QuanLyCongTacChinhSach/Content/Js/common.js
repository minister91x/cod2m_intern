var flag = false;
let currentPage = 1;
let totalPages = 0;
let pageSize = 0;
function ShowToater(type, text, heading, timeOut = 5000) {
    $.toast({
        heading: heading,
        text: text,
        showHideTransition: 'slide',
        icon: type === 'information' ? 'info' : type.toLowerCase(),
        position: 'bottom-right',
        hideAfter: timeOut
    })
}
