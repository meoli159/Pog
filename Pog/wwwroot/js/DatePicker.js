

// Today's Date
var todayDate = new Date();

// Future Due Date
var TopicDueDate = $('#TopicDueDate');

// Due Date Due Today!
var CommentDueDate = $('#CommentDueDate');


// selected dueDate is in the future
if (TopicDueDate < todayDate) {
    $('#btnSubmit').prop('disabled');

} else if (CommentDueDate < todayDate) {
    alert('Task Due date is due today!');
} else {
    alert('Due date is in the future from todays date!');
}


