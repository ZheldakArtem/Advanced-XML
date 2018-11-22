<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:b="http://library.by/catalog">

  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
	<rss version="2.0" xmlns:atom="http://www.w3.org/2005/Atom">
	  <channel>
		<title>Task 2. XML to RSS</title>
		<link></link>
		<description>Book catalog</description>
		<xsl:apply-templates />
	  </channel>
	</rss>
  </xsl:template>

  <xsl:template match="b:book">
	<item>
	  <xsl:apply-templates select="b:title"/>
	  <xsl:choose>
		<xsl:when test="b:genre='Computer' and b:isbn">
		  <link>
			<xsl:value-of select="concat('http://my.safaribooksonline.com/', b:isbn)"/>
		  </link>
		</xsl:when>
		<xsl:otherwise>
		  <link></link>
		</xsl:otherwise>
	  </xsl:choose>
	  <xsl:apply-templates select="b:description"/>
	  <xsl:apply-templates select="b:publish_date"/>
	</item>
  </xsl:template>

  <xsl:template match="b:title">
	<title>
	  <xsl:value-of select="." />
	</title>
  </xsl:template>
  
  <xsl:template match="b:description">
	<description>
	  <xsl:value-of select="." />
	</description>
  </xsl:template>

  <xsl:template match="b:publish_date">
	<pubDate>
	  <xsl:value-of select="." />
	</pubDate>
  </xsl:template>
  
</xsl:stylesheet>
<!--http://my.safaribooksonline.com/<isbn>/-->
