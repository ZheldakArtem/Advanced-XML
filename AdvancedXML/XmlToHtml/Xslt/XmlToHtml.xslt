<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
	xmlns:b="task3/book/catalog">

  <xsl:output method="html" indent="yes"/>
  <xsl:param name="CurrentDate" />

  <xsl:template match="/">
	<html>
	  <head>
		<title>Current funds by genre</title>
	  </head>
	  <body>
		<h1>
		  <xsl:value-of select="$CurrentDate"/>
		</h1>

		<xsl:call-template name="ComputerGenre">
		  <xsl:with-param name="Genre">Computer</xsl:with-param>
		</xsl:call-template>

		<xsl:call-template name="ComputerGenre">
		  <xsl:with-param name="Genre">Fantasy</xsl:with-param>
		</xsl:call-template>

		<xsl:call-template name="ComputerGenre">
		  <xsl:with-param name="Genre">Romance</xsl:with-param>
		</xsl:call-template>

		<xsl:call-template name="ComputerGenre">
		  <xsl:with-param name="Genre">Horror</xsl:with-param>
		</xsl:call-template>

		<xsl:call-template name="ComputerGenre">
		  <xsl:with-param name="Genre">Science Fiction</xsl:with-param>
		</xsl:call-template>
		<hr/>
		<h2>
		  The libruary has <xsl:value-of select="count(b:catalog/b:book)"/> books
		</h2>
	  </body>
	</html>
  </xsl:template>

  <xsl:template match="b:book[b:genre='Computer']">
	<xsl:apply-templates select="b:genre"/>
  </xsl:template>

  <xsl:template name="ComputerGenre">
	<xsl:param name="Genre"/>
	<xsl:variable name="CountOfBooks">
	  <xsl:value-of select="count(b:catalog/b:book[b:genre=$Genre])"/>
	</xsl:variable>
	<h1>
	  <xsl:value-of select="$Genre"/> literature
	</h1>
	<table border="1px">
	  <tr>
		<th>Author</th>
		<th>Title</th>
		<th>Publish Date</th>
		<th>Registration Date</th>
	  </tr>
	  <xsl:for-each select="b:catalog/b:book[b:genre=$Genre]">
		<tr>
		  <td>
			<xsl:value-of select="./b:author"/>
		  </td>
		  <td>
			<xsl:value-of select="./b:title"/>
		  </td>
		  <td>
			<xsl:value-of select="./b:publish_date"/>
		  </td>
		  <td>
			<xsl:value-of select="./b:registration_date"/>
		  </td>
		</tr>
	  </xsl:for-each>
	  <tr></tr>
	</table>
	<b>
	  Count: <xsl:value-of select="$CountOfBooks"/>
	</b>
  </xsl:template>
</xsl:stylesheet>
