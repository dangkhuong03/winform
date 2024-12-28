// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    updateDropdowns();

    $('#createModal').on('shown.bs.modal', function () {
        console.log("Modal opened.");
        // Thực hiện các hành động khi modal được mở, ví dụ:
        // Đặt focus vào ô input đầu tiên
        $('#CrProjectID').focus();
    });


});

var star1Value = false;

var selectedIssueType = null;
let cachedData = null;

// Cập nhật tất cả dropdowns
function updateDropdowns() {
    if (cachedData) {
        populateDropdowns(cachedData);
    } else
    {
        $.ajax({
            url: '/api/API/all-params',
            type: 'GET',
            success: function (data) {
                cachedData = data; 
                populateDropdowns(data); 
            },
            error: function (xhr, status, error) {
                console.error("Error loading data: ", error);
            }
        });
    }
}
function loaddropdown(type) {

    if (type = "PROJECT") {
        //project
        const clientDropdown = $('#crClient-dropdown');
        clientDropdown.empty().append('<option value="">Select Client</option>');
        if (cachedData.clients && Array.isArray(cachedData.clients)) {
            $.each(cachedData.clients, function (index, item) {
                const clientTypeHTML = `
            <div class="dropdown-item" data-value="${item.clientid}" onclick="selectClient('${item.clientName}','${item.clientName}')">
                <span>${item.clientName}</span>
            </div>`;
                clientDropdown.append(clientTypeHTML);

            });
        }
        const picDropdown = $('#crpic-dropdown');
        picDropdown.empty().append('<option value="">Select PIC</option>');
        if (cachedData.user && Array.isArray(cachedData.user)) {
            $.each(cachedData.user, function (index, item) {
                const picTypeHTML = `
            <div class="dropdown-item" data-value="${item.userId}" onclick="selectPic('${item.userName}','${item.userName}')">
                <span>${item.userName}</span>
            </div>`;
                picDropdown.append(picTypeHTML);

            });
        }
    }
    else if (type = "EPIC") {

    }
    

}

function populateDropdowns(data)
{
    const clientDropdown = $('#crClient-dropdown');
    clientDropdown.empty().append('<option value="">Select Client</option>');
    if (data.clients && Array.isArray(data.clients)) {
        $.each(data.clients, function (index, item) {
            const clientTypeHTML = `
                <div class="dropdown-item" data-value="${item.clientid}" onclick="selectClient('${item.clientName}','${item.clientName}')">
                    <span>${item.clientName}</span>
                </div>`;
            clientDropdown.append(clientTypeHTML);

        });
    }
    // Cập nhật dropdown assign
    const assignDropdown = $('#crassign-dropdown');
    assignDropdown.empty().append('<option value="">Select Assign</option>');
    if (data.user && Array.isArray(data.user)) {
        $.each(data.user, function (index, item) {
            const assignTypeHTML = `
                <div class="dropdown-item" data-value="${item.userId}" onclick="selectAssign('${item.userName}','${item.userName}')">
                    <span>${item.userName}</span>
                </div>`;
            assignDropdown.append(assignTypeHTML);
        });
    }

    // Cập nhật dropdown status
    const statusDropdown = $('#crstatus-dropdown');
    statusDropdown.empty().append('<option value="">Select Status</option>');
    if (data.status && Array.isArray(data.status)) {
        $.each(data.status, function (index, item) {
            const statusTypeHTML = `
                <div class="dropdown-item" data-value="${item.status}" onclick="selectStatus('${item.status}','${item.status}')">
                    <span>${item.status}</span>
                </div>`;
            statusDropdown.append(statusTypeHTML);
        });
    }


    // Cập nhật dropdown pic
    const picDropdown = $('#crpic-dropdown');
    picDropdown.empty().append('<option value="">Select PIC</option>');
    if (data.user && Array.isArray(data.user)) {
        $.each(data.user, function (index, item) {
            const picTypeHTML = `
                <div class="dropdown-item" data-value="${item.userId}" onclick="selectPic('${item.userName}','${item.userName}')">
                    <span>${item.userName}</span>
                </div>`;
            picDropdown.append(picTypeHTML);

        });
    }

    //issue type
    const issueDropdown = $('#crissuetype-dropdown');
    issueDropdown.empty().append('<option value="">Select Issue Type</option>');
    let iconPath = '';
    if (data.issueType && Array.isArray(data.issueType)) {
        $.each(data.issueType, function (index, item) {
            let iconPath = '';

            switch (item.issuE_TYPE) {
                case "PROJECT":
                    iconPath = projectIconPath; // Sử dụng biến đã định nghĩa
                    break;
                case "EPIC":
                    iconPath = epicIconPath; // Sử dụng biến đã định nghĩa
                    break;
                case "TASK":
                    iconPath = taskIconPath; // Sử dụng biến đã định nghĩa
                    break;
                case "ISSUE":
                    iconPath = issueIconPath; // Sử dụng biến đã định nghĩa
                    break;
                default:
                    iconPath = '';
            }
            const optionHTML = `
                    <div class="dropdown-item" data-value="${item.issuE_TYPE}" onclick="selectIssueType('${item.issuE_TYPE}', '${item.issuE_TYPE}', '${iconPath}')">
                        <img class="icon" src="${iconPath}" alt="${item.issuE_TYPE}">
                        <span>${item.issuE_TYPE}</span>
                    </div>
                `;

            issueDropdown.append(optionHTML);
        });
    }

    // project type
    const projectypeDropdown = $('#crprojecttype-dropdown');
    projectypeDropdown.empty().append('<option value="">Select Project Type</option>');
    if (data.projectTypes && Array.isArray(data.projectTypes)) {
        $.each(data.projectTypes, function (index, item) {

            const projectypHTML = `
                    <div class="dropdown-item" data-value="${item.projecT_TYPE}" onclick="selectProjectType('${item.projecT_TYPE}', '${item.projecT_TYPE}')">                       
                        <span>${item.projecT_TYPE}</span>
                    </div>`;

            projectypeDropdown.append(projectypHTML);
        });
    }
    ///crprioritylevel
    const priorityDropdown = $('#crpriority-dropdown');
    priorityDropdown.empty().append('<option value="">Select Priority</option>');
    if (data.priorityLevel && Array.isArray(data.priorityLevel)) {
        $.each(data.priorityLevel, function (index, item) {
            // Check if item and item.text are defined

            let iconPath = '';

            // Use item.text for the switch statement
            switch (item.priority_Level) {
                case "HIGH":
                    iconPath = priorityhigh;
                    break;
                case "LOW":
                    iconPath = prioritylow;
                    break;
                case "MEDIUM":
                    iconPath = prioritymedium;
                    break;
                default:
                    iconPath = '';
            }

            const priorityHTML = `
                        <div class="dropdown-item" data-value="${item.priority_Level}" onclick="selectPriority('${item.priority_Level}','${item.priority_Level}', '${iconPath}')">
                            <img   src="${iconPath}" alt="${item.priority_Level}">
                            <span>${item.priority_Level}</span>
                        </div>
                    `;

            priorityDropdown.append(priorityHTML);
        });
    }

    if (data.teams && Array.isArray(data.teams)) {

        let teamDropdown = document.querySelector("#crTeamDropdown");

        let tagify = new Tagify(teamDropdown, {
            enforceWhitelist: true,
            dropdown: {
                enabled: 0,
                maxItems: 10,
                classname: "tags-look",
                closeOnSelect: false,
                highlightFirst: true
            },
            whitelist: data.teams.map(item => item.teamName)
        });

    }

    if (data.label && Array.isArray(data.label)) {

        let labelDropdown = document.querySelector("#crLabelDropdown");

        let tagify1 = new Tagify(labelDropdown, {
            enforceWhitelist: false,
            dropdown: {
                enabled: 0,
                maxItems: 10,
                classname: "tags-look",
                closeOnSelect: false,
                highlightFirst: true
            },
            whitelist: data.label.map(item => item)
        });

    }
}
function submitForm() {
    // Lấy giá trị từ form
    const formData = {
        code: document.getElementById('CrProjectID').value,
        issueType: document.getElementById('IssueType').value,
        name: document.getElementById('Name').value
        // Thêm các giá trị khác nếu cần
    };

    console.log("Submitted Data:", formData);

    $.ajax({
        url: '/api/items', // Thay URL này bằng endpoint API của bạn
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(formData),
        success: function (response) {
            alert("Item created successfully!");
            $('#createModal').modal('hide'); // Đóng modal sau khi thành công
        },
        error: function (error) {
            console.error("Error:", error);
            alert("An error occurred. Please try again.");
        }
    });
}

function CreateForm() {
    const ProjectID = $('#CrProjectID');
    ProjectID.empty();
    $.ajax({
        url: '/api/API/maxProjectID',
        type: 'GET',
        success: function (data) {
            ProjectID.val(data);
        },
        error: function (xhr, status, error) {
            console.error("Lỗi khi tải trạng thái: ", error);
        }
    });

}
function CloseForm() {
    // Khi modal được đóng

    $('#createModal input').val('');
    $('#createModal .dropdown-selected span').text('Select'); // Reset dropdown về trạng thái mặc định
    $('#createModal .dropdown-items').hide(); // Đảm bảo dropdown được ẩn
    $('#Task-fields, #Epic-fields, #project-fields, #issue-fields').hide(); // Ẩn tất cả các trường
    $('#crpriority-selected img').remove();
    $('#crissuetype-selected img').remove();

}

//filter button (Listview)
function applyFilter() {
    const input = document.querySelector('.search-boxs').value;
    const status = document.getElementById('lstatusDropdown').value;
    const assign = document.getElementById('lassignDropdown').value;
    const pic = document.getElementById('lpicDropdown').value;
    const clientid = document.getElementById('lclientDropdown').value;

    $.ajax({
        url: '/Home/filterData',
        type: 'GET',
        data: { input: input, status: status, clientid: clientid, assign: assign, pic: pic },
        success: function (data) {
            $('.project-list-update').html(data); // Cập nhật nội dung của partial view
        },
        error: function (xhr, status, error) {
            console.error("Lỗi khi lọc dữ liệu: ", error);
        }
    });
}


//modal
function selectIssueType(value, text, iconPath) {
    // Xóa icon cũ nếu tồn tại
    $('#crissuetype-selected img').remove();
    //document.getElementById('Task-fields').style.display = 'none';
    //document.getElementById('Epic-fields').style.display = 'none';
    //document.getElementById('project-fields').style.display = 'none';
    //document.getElementById('issue-fields').style.display = 'none';
    $('#createModal input').val('');
    $('#createModal .dropdown-selected span').text('Select'); // Reset dropdown về trạng thái mặc định
    $('#createModal .dropdown-items').hide(); // Đảm bảo dropdown được ẩn
    $('#Task-fields, #Epic-fields, #project-fields, #issue-fields').hide(); // Ẩn tất cả các trường

    // Show the relevant fields based on the selected issue type
    if (value === 'TASK') {
        document.getElementById('Task-fields').style.display = 'block';

    } else if (value === 'EPIC') {
        document.getElementById('Epic-fields').style.display = 'block';
    } else if (value === 'PROJECT') {
        document.getElementById('project-fields').style.display = 'block';
    }
    else if (value === 'ISSUE') {
        document.getElementById('issue-fields').style.display = 'block';
    }


    // Cập nhật nội dung text và thêm icon mới
    $('#crissuetype-selected span').text(text);
    $('#crissuetype-selected').prepend(`<img class="icon" src="${iconPath}" alt="${text}">`);

    // Đóng dropdown
    $('#crissuetype-dropdown').hide();
}




function selectPriority(value, text, iconPath) {
    // Xóa icon cũ nếu tồn tại
    $('#crpriority-selected img').remove();

    // Cập nhật nội dung text và thêm icon mới
    $('#crpriority-selected span').text(text);
    $('#crpriority-selected').prepend(`<img class="icon" src="${iconPath}" alt="${text}">`);

    // Đóng dropdown
    $('#crpriority-dropdown').hide();
}
function selectStatus(value, text) {

    // Cập nhật nội dung text và thêm icon mới
    $('#crstatus-selected span').text(text);

    // Đóng dropdown
    $('#crstatus-dropdown').hide();
}
function selectClient(value, text) {

    // Cập nhật nội dung text và thêm icon mới
    $('#crClient-selected span').text(text);

    // Đóng dropdown
    $('#crClient-dropdown').hide();
}
function selectAssign(value, text) {

    // Cập nhật nội dung text và thêm icon mới
    $('#crassign-selected span').text(text);;

    // Đóng dropdown
    $('#crassign-dropdown').hide();
}
function selectPic(value, text) {

    // Cập nhật nội dung text và thêm icon mới
    $('#crpic-selected span').text(text);;

    // Đóng dropdown
    $('#crpic-dropdown').hide();
}



//event click
function toggleissuetypeDropdown() {
    $('#crissuetype-dropdown').toggle();
}
function togglestatusDropdown() {
    $('#crstatus-dropdown').toggle();
}
function togglePriorityDropdown() {
    $('#crpriority-dropdown').toggle();
}
function toggleissuetypeDropdown() {
    $('#crissuetype-dropdown').toggle();
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";

}

function togglecrpicDropdown() {
    $('#crpic-dropdown').toggle();
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";

}

function toggleProjectTypeDropdown() {
    $('#crprojecttype-dropdown').toggle();
}
function togglePriorityDropdown() {
    $('#crpriority-dropdown').toggle();
}

//function toggleTeamDropdown() {
//    $('#crTeamDropdown').toggle();
//}
//function toggleLabelDropdown() {
//    $('#crLabelDropdown').toggle();
//}
function togglecrprojectDropdown() {
    $('#crproject-dropdown').toggle();
}

function toggleissuetypeDropdown() {
    $('#crissuetype-dropdown').toggle();
}
function togglecrClientDropdown() {
    $('#crClient-dropdown').toggle();
}



// Hàm để thay đổi màu ngôi sao

document.addEventListener('DOMContentLoaded', function () {
    const starElement = document.getElementById('star1');

    starElement.addEventListener('click', toggleStar);

    // Lắng nghe sự kiện tùy chỉnh
    starElement.addEventListener('starToggled', function (e) {
        console.log('Star 1 value:', e.detail.value); // In ra giá trị để kiểm tra
    });
});
function toggleStar() {
    const starElement = document.getElementById('star1');

    starElement.classList.toggle('fas'); // Thay đổi từ far sang fas
    starElement.classList.toggle('startyellow'); // Thêm lớp màu vàng

    // Đảo giá trị star1Value
    star1Value = !star1Value;

    // Phát sự kiện tùy chỉnh
    const event = new CustomEvent('starToggled', { detail: { value: star1Value } });
    starElement.dispatchEvent(event);
}

document.addEventListener('DOMContentLoaded', function () {
    const uploadIcon = document.getElementById('uploadIcon');
    const actualFileInput = document.getElementById('actualFileInput');
    const fileNameInput = document.getElementById('fileNameInput');

    // Khi nhấp vào biểu tượng upload, mở file explorer
    uploadIcon.addEventListener('click', function () {
        actualFileInput.click();
    });

    // Khi chọn file, cập nhật ô nhập văn bản với tên file
    actualFileInput.addEventListener('change', function () {
        const fileName = actualFileInput.files[0] ? actualFileInput.files[0].name : '';
        fileNameInput.value = fileName; // Hiển thị tên file vào ô input
    });
});

// Đóng dropdown khi click ra ngoài
$(document).on('click', function (event) {
    if (!$(event.target).closest('#crissuetype-dropdown, #crissuetype-selected').length) {
        $('#crissuetype-dropdown').css('display', 'none');
    }
    if (!$(event.target).closest('#crprojecttype-dropdown, #crprojecttype-selected').length) {
        $('#crprojecttype-dropdown').css('display', 'none');
    }
    if (!$(event.target).closest('#crpriority-dropdown, #crpriority-selected').length) {
        $('#crpriority-dropdown').css('display', 'none');
    }
    if (!$(event.target).closest('#crstatus-dropdown, #crstatus-selected').length) {
        $('#crstatus-dropdown').css('display', 'none');
    }
    if (!$(event.target).closest('#crlabel-dropdown, #crlabel-selected').length) {
        $('#crlabel-dropdown').css('display', 'none');
    }

});
