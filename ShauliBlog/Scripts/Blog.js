var blogPosts =
    [
        {
            id: 1,
            title: "first",
            publisher: "lior",
            date: "03/06/2019",
            content: "blablabla",
            comments: [{ publisher: "ofek", date: "01/01/2000", content: "hara" }]
        }
    ]

function init() {
    document.getElementById("blog-posts").innerHTML = "";
    for (var i = 0; i < blogPosts.length; i++) {
        document.getElementById("blog-posts").innerHTML += getBlogPostHtml(blogPosts[i]);
    }
}

function getBlogPostHtml(blogPost) {
    return '<li class="blogPost"><header><h2>' + blogPost.title + '</h2>' +
        '<p>Posted on ' + blogPost.date + ' by ' + blogPost.publisher + ' - <a href="#comments">'
        + blogPost.comments.length + ' comments</a></p>' +
        '</header><div><p>' + blogPost.content + '</p></div></li>';
}

function filterPosts() {
    var blogPostsCopy = blogPosts.slice();

    if (document.getElementById("start-date").value !== "" && document.getElementById("end-date").value !== "") {
        blogPostsCopy = filterPostsByDate(blogPostsCopy);
    }
    if (document.getElementById("publisher").value !== undefined) {
        blogPostsCopy = filterPostsByPublisher(blogPostsCopy);
    }

    document.getElementById("blog-posts").innerHTML = "";

    for (var i = 0; i < blogPostsCopy.length; i++) {
        document.getElementById("blog-posts").innerHTML += getBlogPostHtml(blogPostsCopy[i]);
    }
}

function filterPostsByPublisher(blogPostsCopy) {
    var publisher = document.getElementById("publisher").value

    for (var i = 0; i < blogPostsCopy.length; i++) {
        if (publisher !== blogPostsCopy[i].publisher) {
            blogPostsCopy.splice(i, 1);
        }
    }

    return blogPostsCopy;
}

function filterPostsByDate(blogPostsCopy) {
    var europeanDateFormat;
    var blogPostDate;
    var startDate = new Date(document.getElementById("start-date").value);
    var endDate = new Date(document.getElementById("end-date").value);

    for (var i = 0; i < blogPostsCopy.length; i++) {
        europeanDateFormat = blogPostsCopy[i].date.split("/");
        blogPostDate = new Date(europeanDateFormat[2], europeanDateFormat[1] - 1, europeanDateFormat[0]);
        blogPostDate.setHours(3);

        if (blogPostDate < startDate || blogPostDate > endDate) {
            blogPostsCopy.splice(i, 1);
        }
    }

    return blogPostsCopy;
}   
