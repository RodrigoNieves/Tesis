x <- c(1998,1999,2000,2001,2002,2003,2004,2005,2006,2007,2008,2009,2010,2011,2012,2013,2014)
y <- c(1.61,1.81,2.50,1.90,2.57,1.99,2.53,3.17,2.98,3.67,4.16,3.56,3.48,4.15,4.00,4.59,5.35)
PNGxlabel <- "año"
PNGylabel <- "Puntos sobre la media"
PNGwidth <- 900
PNGheight<- 450
imageName <- "MexicoPM"


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
if(!exists("x")){
  x <- 1:100  
}
if(!exists("y")){
  y <- rnorm(100)  
}
if(!exists("imageName")){
  imageName <- "xyplot"
}
df <- data.frame(x,y)

library(ggplot2)

png(paste0(imageName,".png"),width = PNGwidth, height = PNGheight)
g <- ggplot(data= df, aes(x = x,y = y))
g <- g + geom_line()
g <- g + xlab(PNGxlabel)
g <- g + ylab(PNGylabel)
print(g + scale_x_continuous(breaks = seq(1998,2014) )+geom_smooth())
dev.off()


