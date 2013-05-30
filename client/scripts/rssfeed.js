$(document).ready(function (){
$('.btnsubmit input').click(function(){	
	$('#newsfeedresult').each(function(){
		var $container = $(this);
		$container.empty();
		
		var feedUrl = $('#urlProxy').val();
		feedUrl+= '?uri=';
		feedUrl+= $('#queryStringUrl').val();
		
		
		$.get(feedUrl, function(data) {
		    var $xml = $(data);
		    
		    try{
			    var $items = $xml.find('item');
			    
			    $items.each(function(){
			       	try
			       	{
				    	var $headline = $('<h4>Headline here..</h4>').append($('title', this).text());
				    	var $description = $('<p>Headline here..</p>').append($('description', this).text());
				    	var $textlink = $('<a></a>')
				    		.attr('href', $('link', this).text())
			    			.text($('title', 'story link'));
//				    	var $img1 = $('<img></img>')
//			    		.attr('src', $('media:thumbnail', this).firstchild.('url').text())
//		    			.text($('title', 'image'));
						$('<div></div>')
							.append($headline)
							.append($description)
							.append($textlink)
	//						.append($img1)
							.appendTo($container);
			       	}
			       	catch(exception){
						var $headline = $('<h4>Item empty</h4>').append($xml);
						$('<div>No item here.</div>')
							.append($headline)
							.appendTo($container);			       		
			       	}
				});
		    }
		    catch(exception)
		    {
				var $headline = $('<h4>Headline here..</h4>').append($xml);
				$('<div>No items found in this feed..</div>')
					.append($headline)
					.appendTo($container);
		    }
		    
		});	
	});
});
});



