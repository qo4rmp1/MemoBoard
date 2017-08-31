$(function () {
	$(document).delegate('#EditArticleModal #editBtn', 'click', function () {
		$('#EditArticleModal form').submit();
	});
});
