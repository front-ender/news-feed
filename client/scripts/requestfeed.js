$(document).ready(function (){
$('#btnOk').click(function(){	
	$('#newsfeed').each(function(){
		var $container = $(this);
		$container.empty();
		
		var feedUrl = $('#urlfeed').val();
		
		$.get(feedUrl, function(data) {
		    var $xml = $(data);
		    
				var $link = $('<a></a>').text();
					.attr('href', $('link', this).text())
					.text($('title', this).text());
				var $headline = $('<h4></h4>').append($link);
				$('<div></div>')
					.append($headline)
					.appendTo($container);
			});
		});	
	});	
});


