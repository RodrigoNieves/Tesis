if(!exists("PNGwidth")){
  PNGwidth <- 480
}
if(!exists("PNGheight")){
  PNGheight <- 480
}
if(!exists("PNGxlabel")){
  PNGxlabel <- ""
}
if(!exists("PNGylabel")){
  PNGylabel <- ""
}
if(!exists("x1")){
  x1 <- 1:100  
}
if(!exists("y1")){
  y1 <- rnorm(100)  
}

if(!exists("x2")){
  x2 <- 1:30  
}
if(!exists("y2")){
  y2 <- rnorm(30)  
}

if(!exists("imageName")){
	imageName <- "xyplot"
}

png(paste0(imageName,".png"),width = PNGwidth, height = PNGheight)
plot(x1,y1,type= "l", xlab = PNGxlabel, ylab = PNGylabel, col="red")
lines(x2,y2, col="green")
dev.off()
