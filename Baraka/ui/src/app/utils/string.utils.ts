export class StringUtils {

  /**
   * Retraite une chaîne de caractère pour en faire un code pseudo-SQL correct.
   * @param value Valeur traitée.
   */
  public static StringToCode(value: string): string {
    return value
      .replace(new RegExp("[^a-zA-Z0-9]+", "g"), "_")
      .toLowerCase();
  }
}
